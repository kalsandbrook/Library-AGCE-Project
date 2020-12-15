SELECT Username,BookID from USERS
INNER JOIN Loans
ON Users.UserID = Loans.UserID