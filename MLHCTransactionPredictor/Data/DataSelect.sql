SELECT	F.FileNumber AS sFileNumber, F.OfficeID AS vOffice, PC.Name AS vCoverageType, PROP.State AS vState,
		CASE WHEN PATINDEX('%(%', PROD.DisplayName) > 0
		THEN SUBSTRING(PROD.DisplayName, 0, PATINDEX('%(%', PROD.DisplayName) - 1)
		ELSE PROD.DisplayName
		END AS vProduct,
		TRANS.Name AS vTransaction,
		ISNULL (LN.LoanAmount, 0) AS nLoanAmount, ISNULL(LI.[Lien Amounts], 0) AS nLienAmounts,
		ISNULL(LN.LoanAmount, 0) - ISNULL(LI.[Lien Amounts], 0) AS nEquity, CONVERT(DECIMAL(16, 1), ISNULL(LI.Liens, 0)) AS nLiens,
		(SELECT COUNT(*) FROM FileActions A WITH (NOLOCK) WHERE A.FileID = F.FileID) AS nActions,
		(SELECT COUNT(*) FROM Audit AD WITH (NOLOCK) WHERE AD.FileID = F.FileID) AS nAuditEntries,
		(SELECT COUNT(*) FROM Lien L WITH (NOLOCK) WHERE L.FileID = F.FileID) AS nTotalExceptions,
		(SELECT COUNT(*) FROM Note N WITH (NOLOCK) WHERE N.FileID = F.FileID) AS nTotalNotes,
		CASE WHEN S.Name = 'Cancelled' THEN '1.0' ELSE '0.0' END AS oCancelled,
		CONVERT(DECIMAL(16, 1), ISNULL(DATEDIFF(DAY, dbo.fn_GetLocalDateTimeFunc(F.OpenedDate, 4), CL.DateClosed), 45)) AS oNumDays
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