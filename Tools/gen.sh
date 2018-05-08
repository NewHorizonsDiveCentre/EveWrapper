#! /bin/bash
CONTEXT_FILE=EveContextGen

rm -rf ../EveWrapper/Models
dotnet ef dbcontext scaffold 'Server=localhost;uid=sa;pwd=Default-Pword1;Database=test' Microsoft.EntityFrameworkCore.SqlServer -d -f -o ../EveWrapper/Models -p ../EveWrapper/EveWrapper.csproj -c $CONTEXT_FILE
mv ../EveWrapper/Models/$CONTEXT_FILE.cs ../EveWrapper/
