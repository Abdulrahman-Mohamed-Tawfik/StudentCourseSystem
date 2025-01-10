@echo off
setlocal enabledelayedexpansion
set "sourceDir=."

(for /d %%d in ("%sourceDir%\*") do (
    if not "%%~nxd" == "bin" if not "%%~nxd" == "obj" (
        echo - %%~nxd
        for /d %%s in ("%%d\*") do (
            if not "%%~nxs" == "bin" if not "%%~nxs" == "obj" (
                echo -- %%~nxs
                for %%f in ("%%s\*") do (
                    if not "%%~nxf" == "bin" if not "%%~nxf" == "obj" if exist "%%f" (
                        if exist %%f echo --- %%~nxf
                    )
                )
                for /d %%t in ("%%s\*") do (
                    if not "%%~nxt" == "bin" if not "%%~nxt" == "obj" (
                        echo --- %%~nxt
                        for %%u in ("%%t\*") do (
                            if not "%%~nxf" == "bin" if not "%%~nxf" == "obj" if exist "%%u" (
                                if exist %%u echo ---- %%~nxf
                            )
                        )
                    )
                )
            )
        )
    )
)) >> project_structure.txt

endlocal
