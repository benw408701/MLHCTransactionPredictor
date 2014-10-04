SELECT F.FileNumber, PROP.State, CNTY.County, LN.LoanAmount, LNTP.Name AS [Loan Type],
		PROD.Name AS Product, TRANS.Name AS [Transaction Type], dbo.fn_GetLocalDateTimeFunc(F.OpenedDate, 4) AS DateOpened,
		CL.DateClosed, DATEDIFF(DAY, dbo.fn_GetLocalDateTimeFunc(F.OpenedDate, 4), CL.DateClosed) AS NumDays,
		S.Name AS Status, LI.[Lien Amounts], LI.Liens,
		(SELECT COUNT(*) FROM FileActions A WITH (NOLOCK) WHERE A.FileID = F.FileID) AS Actions,
		(SELECT COUNT(*) FROM Audit AD WITH (NOLOCK) WHERE AD.FileID = F.FileID) AS [Audit Entries]
FROM	FileMain F WITH (NOLOCK)
		INNER JOIN Status S WITH (NOLOCK) ON S.StatusID = F.StatusID
		INNER JOIN Property PROP WITH (NOLOCK) ON PROP.PropertyID = F.PrimaryPropertyID
		INNER JOIN County CNTY WITH (NOLOCK) ON CNTY.CountyID = PROP.CountyID
		INNER JOIN NewLoan LN WITH (NOLOCK) ON LN.FileID = F.FileID
		LEFT OUTER JOIN LoanType LNTP WITH (NOLOCK) ON LNTP.LoanTypeID = LN.LoanTypeID
		INNER JOIN ActionListProductType PROD WITH (NOLOCK) ON PROD.ActionListProductTypeID = F.ActionListProductTypeID
		INNER JOIN ActionListTransactionType TRANS WITH (NOLOCK) ON TRANS.ActionListTransactionTypeID = F.ActionListTransactionTypeID
		INNER JOIN (
			SELECT	L.FileID, COUNT(*) AS Liens, SUM(L.LienAmount) AS [Lien Amounts]
			FROM	LIEN L WITH (NOLOCK)
			GROUP BY L.FileID) LI ON LI.FileID = F.FileID
		LEFT OUTER JOIN tbl_FilesClosed CL WITH (NOLOCK) ON CL.FileID = F.FileID
WHERE	LN.SequenceNumber = 0 AND (DateClosed IS NOT NULL OR S.Name = 'CANCELLED')
ORDER BY	F.FileNumber;