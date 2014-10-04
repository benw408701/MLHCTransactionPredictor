SELECT F.FileNumber, F.OfficeID, PC.PartnerCompanyID AS CoverageID, PROP.State, PROP.CountyID,
		CASE WHEN S.Name = 'Cancelled' THEN '1' ELSE '0' END AS 'Cancelled',
		PROD.ActionListProductTypeID, TRANS.ActionListTransactionTypeID,
		DATEDIFF(DAY, dbo.fn_GetLocalDateTimeFunc(F.OpenedDate, 4), ISNULL(CL.DateClosed, 1000)) AS NumDays, LN.LoanAmount,
		ISNULL(LI.[Lien Amounts], 0) AS [Lien Amounts], LN.LoanAmount - ISNULL(LI.[Lien Amounts], 0) AS Equity,
		ISNULL(LI.Liens, 0) AS Liens,
		(SELECT COUNT(*) FROM FileActions A WITH (NOLOCK) WHERE A.FileID = F.FileID) AS Actions,
		(SELECT COUNT(*) FROM Audit AD WITH (NOLOCK) WHERE AD.FileID = F.FileID) AS [Audit Entries],
		(SELECT COUNT(*) FROM Lien L WITH (NOLOCK) WHERE L.FileID = F.FileID) AS [Total Exceptions],
		(SELECT COUNT(*) FROM Note N WITH (NOLOCK) WHERE N.FileID = F.FileID) AS [Total Notes]
FROM	FileMain F WITH (NOLOCK)
		INNER JOIN Status S WITH (NOLOCK) ON S.StatusID = F.StatusID
		INNER JOIN Property PROP WITH (NOLOCK) ON PROP.PropertyID = F.PrimaryPropertyID
		INNER JOIN NewLoan LN WITH (NOLOCK) ON LN.FileID = F.FileID
		INNER JOIN ActionListProductType PROD WITH (NOLOCK) ON PROD.ActionListProductTypeID = F.ActionListProductTypeID
		INNER JOIN ActionListTransactionType TRANS WITH (NOLOCK) ON TRANS.ActionListTransactionTypeID = F.ActionListTransactionTypeID
		LEFT OUTER JOIN (
			SELECT	L.FileID, COUNT(*) AS Liens, SUM(L.LienAmount) AS [Lien Amounts]
			FROM	Lien L WITH (NOLOCK)
			WHERE	L.LienAmount > 0
			GROUP BY L.FileID) LI ON LI.FileID = F.FileID
		LEFT OUTER JOIN tbl_FilesClosed CL WITH (NOLOCK) ON CL.FileID = F.FileID
		INNER JOIN FilePartnerRel FP WITH (NOLOCK) ON FP.FileID = F.FileID
		INNER JOIN PartnerCompany PC WITH (NOLOCK) ON PC.PartnerCompanyID = FP.PartnerCompanyID
		INNER JOIN PartnerType PT WITH (NOLOCK) ON PT.PartnerTypeID = FP.PartnerTypeID
WHERE	LN.SequenceNumber = 0 AND (DateClosed IS NOT NULL OR S.Name = 'CANCELLED')
		AND PT.Name = 'Coverage Picker' AND PC.Name <> 'Outsourced';