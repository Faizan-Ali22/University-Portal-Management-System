$files = Get-ChildItem -Path d:\CyberSafe-Git\Web\UniversityApp.API\Controllers\*.cs

foreach ($f in $files) {
    $c = Get-Content $f.FullName -Raw

    if ($f.Name -eq 'CoursesController.cs') {
        $c = $c -replace 'GetAllAsync', 'GetAllCoursesAsync'
        $c = $c -replace 'GetByIdAsync', 'GetCourseByIdAsync'
        $c = $c -replace 'AddAsync', 'AddCourseAsync'
        $c = $c -replace 'UpdateAsync', 'UpdateCourseAsync'
        $c = $c -replace 'DeleteAsync', 'DeleteCourseAsync'
    }
    if ($f.Name -eq 'StudentsController.cs') {
        $c = $c -replace 'GetAllAsync', 'GetAllStudentsAsync'
        $c = $c -replace 'GetByIdAsync', 'GetStudentByIdAsync'
        $c = $c -replace 'SearchAsync', 'SearchStudentsAsync'
        $c = $c -replace 'AddAsync', 'AddStudentAsync'
        $c = $c -replace 'UpdateAsync', 'UpdateStudentAsync'
        $c = $c -replace 'DeleteAsync', 'DeleteStudentAsync'
    }
    if ($f.Name -eq 'FacultyController.cs') {
        $c = $c -replace 'GetAllAsync', 'GetAllFacultiesAsync'
        $c = $c -replace 'GetByIdAsync', 'GetFacultyByIdAsync'
        $c = $c -replace 'AddAsync', 'AddFacultyAsync'
        $c = $c -replace 'UpdateAsync', 'UpdateFacultyAsync'
        $c = $c -replace 'DeleteAsync', 'DeleteFacultyAsync'
    }
    if ($f.Name -eq 'EnrollmentsController.cs') {
        $c = $c -replace 'GetByStudentIdAsync', 'GetByStudentAsync'
        $c = $c -replace 'GetByCourseIdAsync', 'GetByCourseAsync'
        $c = $c -replace 'AddAsync', 'EnrollAsync'
        $c = $c -replace 'DeleteAsync', 'DropAsync'
    }
    if ($f.Name -eq 'AttendanceController.cs') {
        $c = $c -replace 'AddAsync', 'MarkAttendanceAsync'
        $c = $c -replace 'GetAttendanceReportAsync', 'GetReportAsync'
    }
    if ($f.Name -eq 'GradesController.cs') {
        $c = $c -replace 'AddAsync', 'AssignGradeAsync'
        $c = $c -replace 'GetStudentTranscriptAsync', 'GetTranscriptAsync'
    }
    
    Set-Content -Path $f.FullName -Value $c
}
