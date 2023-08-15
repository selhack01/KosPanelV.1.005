
$(document).ready(function() {
    $.ajax({
        url: 'https://localhost:7271/api/Customers', // Endpoint URL
        dataType: 'json',
        success: function(data) {
            var table = new DataTable('#example', {
                data: data, // Use the received JSON data
                columns: [
                    { data: 'id' },
                    { data: 'companyName' },
                    { data: 'companySector' },
                    { data: 'companyWeb' },
                    { data: 'companyMail' },
                    { data: 'companyTel' },
                    { data: 'createDate' },
                    
                    {
                        // Add edit button to each row
                        data: null,
                        render: function (data, type, row, meta) {
                            return '<button class="edit-btn">Edit</button>';
                        }
                    },
                    {
                        // Add switch (checkbox) for active/passive column
                        data: null,
                        render: function (data, type, row, meta) {
                            return '<button class="delete-btn">Delete</button>';
                            
                        },
                    }

                    
                ],
                buttons: [
                    // Your other buttons here (if any)
                ],
                columnDefs: [
                    {
                        targets: [-2, -1], // Last two columns (Edit button and Settings column)
                        orderable: false, // Disable sorting on these columns
                        className: 'dt-body-center'
                    }
                ],
                select: true // Enable row selection
            });

            $('#example tbody').on('click', '.edit-btn', function () {
                var rowData = table.row($(this).closest('tr')).data();
                var customerId = rowData.id;
            
                // Prepare the data to be sent in JSON format
                var requestData = {
                    customerId: customerId
                };
            
                // Send POST request to get customer data by ID
                $.ajax({
                    type: 'GET',
                    url: 'https://localhost:7271/Customer/GetById/' + customerId,
                    data: JSON.stringify(requestData), // Convert the data to JSON format
                    contentType: 'application/json', // Set the content type to JSON
                    success: function(response) {
                        // Handle the success response
                        console.log('GetById request successful.');
                        
                        console.log(response);
            
                        // Save the response data in localStorage
                        localStorage.setItem('customerData', JSON.stringify(response));
            
                        // Redirect to update.html
                        window.location.href = 'update.html';
                    },
                    error: function(xhr, status, error) {
                        // Handle the error
                        console.error('Error while sending GetById request:', error);
                    }
                });
            });


            $(document).ready(function() {
                // Get the customer data from localStorage
                var customerData = JSON.parse(localStorage.getItem('customerData'));
            
                // Check if data is available and use it for editing
                if (customerData) {
                    // Populate the edit form with the data from customerData
                    // Assuming you have input fields with the corresponding IDs:
                    $('#companyIdR').val(customerData.id);
                    $('#companyNameR').val(customerData.companyName);
                    $('#companyEmailR').val(customerData.companyMail);
                    $('#companyTelR').val(customerData.companyTel);
                    $('#companyWebR').val(customerData.companyWeb);
                    $('#companySectorR').val(customerData.companySector);
                }
            });
            

            // Handle "Edit" button click event
            $('#example tbody').on('click', '.delete-btn', function () {
                var rowData = table.row($(this).closest('tr')).data();
                var customerId = rowData.id;
            
                // Prepare the data to be sent in JSON format
                var requestData = {
                    customerId: customerId
                };
            
                // Send POST request to deactivate the customer
                $.ajax({
                    type: 'POST',
                    url: 'https://localhost:7271/Customer/passive/' + customerId,
                    data: JSON.stringify(requestData), // Convert the data to JSON format
                    contentType: 'application/json', // Set the content type to JSON
                    success: function(response) {
                        // Handle the success response
                        alert("Data Deleted!");
                        console.log('Delete request successful.');
                        console.log(response);
                    },
                    error: function(xhr, status, error) {
                        // Handle the error
                        console.error('Error while sending delete request:', error);
                    }
                });
            });

            
            // $('#example tbody').on('click', '.edit-btn', function () {
            //     var rowData = table.row($(this).closest('tr')).data();
            //     // rowData kullanarak düzenleme işlemlerinizi gerçekleştirin
        
            //     // "update.html" sayfasına yönlendirin
            //     window.location.href = 'update.html'; // "update.html"yi istediğiniz güncelleme sayfasının URL'siyle değiştirin
            // });

         
        },
        error: function() {
            // Handle error if needed
        }
    });
});

