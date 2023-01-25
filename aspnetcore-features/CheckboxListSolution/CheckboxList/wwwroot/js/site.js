$(document).ready(function () {
    $('#btnSubmit').on('click', function () {
        $.ajax({
            url: '/Home/CourseSelection',
            type: 'POST',
            data: $('#CoursesForm').serialize(),
            success: function (response) {
                console.log('Success');
            },
            error: function (xhr) {
                console.log(xhr);
            }
        })
    });
});