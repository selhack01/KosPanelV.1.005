document.addEventListener('DOMContentLoaded', function() {
document.getElementById('companyForm').addEventListener('submit', function(event) {
  event.preventDefault();

  var endpointUrl = 'https://localhost:7271/AddCustomer';

  var requestData = {
    companyName: document.getElementById('companyName').value,
    companyWeb: document.getElementById('companyWeb').value,
    companyEmail: document.getElementById('companyEmail').value,
    companySector: document.getElementById('companySector').value,
    companyTel: document.getElementById('companyTel').value
  };
  


  fetch('https://localhost:7271/AddCustomer', {
    method:"POST",
    headers:{
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('token')
    },
    body:JSON.stringify(
      {
        "companyName": requestData.companyName,
        "companyWeb": requestData.companyWeb,
        "companyMail": requestData.companyEmail,
        "companyTel": requestData.companyTel,
        "companySector": requestData.companySector
      }
    )
    })
  .then(res=>console.log(res))
  .then(alert('Create Successful'))
  .then(document.location.reload(true))
});
});