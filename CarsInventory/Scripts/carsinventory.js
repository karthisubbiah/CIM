var CI = {
    SearchInventory: {
        onLoad: function () {
            $('body').on('click', '.modal-link', function (e) {
                e.preventDefault();
                $(this).attr('data-target', '#modal-container');
                $(this).attr('data-toggle', 'modal');
            });
            // Attach listener to .modal-close-btn's so that when the button is pressed the modal dialog disappears
            $('body').on('click', '.modal-close-btn', function () {
                $('#modal-container').modal('hide');
            });
            //clear modal cache, so that new content can be loaded
            $('#modal-container').on('hidden.bs.modal', function () {
                $(this).removeData('bs.modal');
            });
            $('#CancelModal').on('click', function () {
                $('#modal-container').modal('hide');
                return false;
            });
            $('#approve-btn').click(function () {
                $('#modal-container').modal('hide');
            });
            $("table tr th:nth-child(n)").addClass("gridheader");
            $("table tr td:nth-child(n)").addClass("griddata");
        },
        resetForm: function (e) {
            e.closest('form').reset();
        },
        validateSearch: function () {
            var brand = $("#Brand").val();
            var model = $('#Model').val();
            if ($.trim(brand) != '' || $.trim(model) != '') {
                return true;
            }
            else {
                alert('Please enter Brand/Model for your search!');
                return false;
            }
        }
    },
    modalPopup: {
        removeValidation: function (e) {
            e.closest('form').reset();
        }
    },
    login: {
        validateLogin: function () {
            var brand = $("#Email").val();
            var model = $('#Password').val();
            if ($.trim(brand) != '' && $.trim(model) != '') {
                return true;
            }
            else {
                alert('Email/Password cannot be empty!');
                return false;
            }
        }
    }
}