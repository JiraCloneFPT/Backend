# Backend

Project : FPT Jira Clone

Backend Api of FPT Jira Clone.

Install instruction:

I. Requirement: 
1. Net version 6.0 LST (Long-term support)
2. IDE : Visual studio version > 2019
 
II. Install 
1. Clone source code from:  https://github.com/JiraCloneFPT/Backend.git 
2. Change connection string match current local data-source.
3: Open SQL Server, Open file SQL in project and execute it
4: Open Visual studio -> Tools -> Nuget... -> Console -> Paste this command and replace "Admin" with your name server and execute it
	Scaffold-DbContext "Data Source=Admin;Initial Catalog=dbJiraClone;Integrated Security=True;encrypt=false" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
5. Vào Visual studio -> Start with debug.

III. Access Website FPT Jira Clone
1. Role Admin:
  + Account: KhoaLHN
  + Password: 12345
2. Role User:
  + Account: HuyNG5
  + Password: 12345
