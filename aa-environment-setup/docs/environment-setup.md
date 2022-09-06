# Environment Setup for ASP.net Development (Windows10)

## Setup Folder Structure

- Create the following folders in the C drive:
  - C:\ASPdotnetDev
  - C:\ASPdotnetDev\repos
---

## Create a GitHub Account

- [GitHub Website](https://github.com)
- Go to GitHub and create an account if you do not have one. Choose an appropriate username that has your first and last name in it. Remember the username that you create the account with as well as the email that you use. You will need this information to complete the setup.

---

## Download Git

- [Git Website](https://git-scm.com/)

- Download the latest version. Allow all the defaults on download. The path should be updated automatically, so that `git` is available from any directory.
- Open a PowerShell or CMD terminal. In the shell run `git –version` to make sure that git is installed and accessible from this directory. Note that it is two minus bars before version. If a version number is not returned, the path must be set so that `git` is available from any directory. To set the path, in the search area at the bottom of the windows task bar type `env` and select `Edit Environment Variables for your Account`. Then edit the `PATH` and add new `C:\Program Files\Git\cmd`. You could add this to the system environments alternatively. Now you can run the `git` command from a terminal anywhere.
  
----

## Download GitHub CLI

- [GitHub CLI Website](https://cli.github.com/) (*Command-Line Interface*)

- Download the latest version. Allow all the defaults on download. The path should be updated automatically, so that `gh` is available from any directory.
  
----

## Download Visual Studio Code

- [Visual Studio Code Website](https://code.visualstudio.com)
- Download Visual Studio Code if you do not already have it on your machine.
- From VS Code install the extension `C# by Microsoft - powered by OmniSharp`.

----

## Download Visual Studio 2022 Community Edition

- [Visual Studio 2022, Community Edition](https://visualstudio.microsoft.com/) 
  - When you load VS 2022, `dotnetcore 6 sdk` will also be downloaded to your machine.

---

## Download SQL Server 2019

- [SQL Server 2019](https://www.microsoft.com/sql-server/sql-server-downloads) or higher, **Developer Edition**

---

## Download SQL Server Management Studio

- [SQL Server Management Studio](https://docs.microsoft.com/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15#download-ssms) (*SSMS*)

---

## Download LinkPad 7

- [LinkPad 7](https://www.linqpad.net/Download.aspx)

----
