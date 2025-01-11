@echo off
setlocal enabledelayedexpansion
set "sourceDir=."

:: Loop through each folder in the source directory
(for /d %%d in ("%sourceDir%\*") do (
    if not "%%~nxd" == "bin" if not "%%~nxd" == "obj" if not "%%~nxd" == ".github" (
        echo - %%~nxd
        for /d %%s in ("%%d\*") do (
            if not "%%~nxs" == "bin" if not "%%~nxs" == "obj" (
                echo -- %%~nxs
                for %%f in ("%%s\*") do (
                    if not "%%~nxf" == "bin" if not "%%~nxf" == "obj" if exist "%%f" (
                        if exist %%f echo --- %%~nxf
                    )
                )
                :: Loop through subfolders inside Features (like Courses, Students)
                for /d %%t in ("%%s\*") do (
                    if not "%%~nxt" == "bin" if not "%%~nxt" == "obj" (
                        echo --- %%~nxt
                        :: For each subfolder, list its subfolders (e.g., Commands, Queries)
                        for /d %%u in ("%%t\*") do (
                            if not "%%~nxu" == "bin" if not "%%~nxu" == "obj" (
                                echo ---- %%~nxu
                                :: If there are files in that folder, list them
                                for %%v in ("%%u\*") do (
                                    if not "%%~nxv" == "bin" if not "%%~nxv" == "obj" if exist "%%v" (
                                        echo ----- %%~nxv
                                    )
                                )
                            )
                        )
                    )
                )
            )
        )
    )
)) >> project_structure.txt

endlocal
