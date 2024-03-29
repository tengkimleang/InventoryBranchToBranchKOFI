
GO
/****** Object:  StoredProcedure [dbo].[KOFI_ADDON_BRANCH_TO_BRANCH]    Script Date: 2022/11/10 2:10:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC KOFI_ADDON_BRANCH_TO_BRANCH 'SERIES','59','','','',''
--EXEC KOFI_ADDON_BRANCH_TO_BRANCH 'Branch','','','','',''
ALTER PROC [dbo].[KOFI_ADDON_BRANCH_TO_BRANCH]
	@TYPE AS NVARCHAR(MAX),
	@par1 AS NVARCHAR(MAX),
	@par2 AS NVARCHAR(MAX),
	@par3 AS NVARCHAR(MAX),
	@par4 AS NVARCHAR(MAX),
	@par5 AS NVARCHAR(MAX)
AS
BEGIN
	IF @TYPE='SERIES'
	BEGIN
		IF @par1='59'
		BEGIN
			SELECT Series,SeriesName,(SELECT ISNULL(MAX(DocNum)+1,B.InitialNum) FROM OIGN WHERE Series=B.Series)AS DocNum FROM OFPR AS A 
			LEFT JOIN NNM1 AS B ON A.Indicator=B.Indicator
			WHERE Category='202204'/*YEAR(GETDATE())*/ AND B.ObjectCode=59 AND SubNum=MONTH(GETDATE())
		END
		ELSE IF @par1='60'
		BEGIN
			SELECT 
				 Series
				,SeriesName
				,(SELECT ISNULL(MAX(DocNum)+1,B.InitialNum) FROM OIGE WHERE Series=B.Series)AS DocNum 
				--,Category
				--,SubNum
			FROM OFPR AS A 
			LEFT JOIN NNM1 AS B ON A.Indicator=B.Indicator
			WHERE B.ObjectCode=60 AND SubNum=MONTH(GETDATE()) AND Category='202204' --AND Category=YEAR(GETDATE())  
		END
	END
	ELSE IF @TYPE='PriceList'
	BEGIN
		SELECT ListNum AS Code,ListName AS Name FROM OPLN
	END
	ELSE IF @TYPE='Branch'
	BEGIN
		SELECT BPLID AS Code,BPLName AS Name FROM OBPL ORDER BY BPLId
	END
	ELSE IF @TYPE='WHsByBranch'
	BEGIN
		SELECT DfltResWhs FROM OBPL WHERE BPLID=@par1
	END
	ELSE IF @TYPE='GetItemByFilter'
	BEGIN
		IF @par1='*'
		BEGIN
			SELECT 
				 A.ItemCode
				,A.ItemName
				,B.OnHand
				,C.Price 
				,CASE WHEN A.ManBtchNum='Y' THEN
				'B'
				 WHEN A.ManSerNum='Y' THEN
					'S'
				 ELSE
					'N'
				 END AS ManageItem
			FROM OITM AS A
			LEFT JOIN OITW AS B ON A.ITEMCODE=B.ITEMCODE AND WhsCode=@par2
			LEFT JOIN ITM1 AS C ON A.ItemCode=C.ItemCode AND PriceList=@par3
		END
		ELSE
		BEGIN
			SELECT 
				 A.ItemCode
				,A.ItemName
				,B.OnHand
				,C.Price 
				,CASE WHEN A.ManBtchNum='Y' THEN
				'B'
				 WHEN A.ManSerNum='Y' THEN
					'S'
				 ELSE
					'N'
				 END AS ManageItem
			FROM OITM AS A
			LEFT JOIN OITW AS B ON A.ITEMCODE=B.ITEMCODE AND WhsCode=@par2
			LEFT JOIN ITM1 AS C ON A.ItemCode=C.ItemCode AND PriceList=@par3
			WHERE A.ItemCode LIKE '%'+@par1+'%'
		END
	END
	ELSE IF @TYPE='Batch'
	BEGIN
		SELECT 
				A.ItemCode,
				A.DistNumber,
				B.Quantity,
				A.ExpDate,
				0 AS InputQty
			FROM OBTN AS A
			LEFT JOIN OBTQ AS B ON A.ItemCode=B.ItemCode AND A.SysNumber=B.SysNumber
			WHERE A.ItemCode=@par1 AND B.WhsCode=@par2 AND B.Quantity!=0;
	END
	ELSE IF @TYPE='SERIAL'
	BEGIN
		SELECT 
			  T0.[ItemCode]
			, T0.[IntrSerial] AS Serial
			, 1 AS Qty
		FROM OSRI T0  
		--INNER JOIN OWHS T1 ON T0.WhsCode = T1.WhsCode 
		WHERE T0.[Status] <> 1 AND T0.ITEMCODE=@par1 AND T0.WhsCode=@par2
		Group by T0.[ItemCode], T0.[ItemName], T0.[SuppSerial], T0.[IntrSerial], T0.[BatchId]
	END
	ELSE IF @TYPE='UpdateDocEntryToGoodIReceptAndUpdateDocEntryToGoodIssue'
	BEGIN
		UPDATE OIGN SET U_LinkToGoodIssue=@par2 WHERE DocEntry=@par1; --Update DocEntry To Good Receipt From Good Issue
		UPDATE OIGE SET U_LinkToGoodReceipt=@par1 WHERE DocEntry=@par2; --Update DocEntry To Good Issue From Good Receipt
		UPDATE dbo.[@TB_OTRF_B_2_B] SET U_Approve='Approve' WHERE DocEntry=@par3; --Update Status To Inventory Transfer Draft
		SELECT 'S' AS A;
	END
END