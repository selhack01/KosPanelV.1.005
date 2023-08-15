
document.getElementById('UpdateForm').addEventListener('submit', function() {
  event.preventDefault();

     var companyId = document.getElementById('companyIdR').value;
     var companyName = document.getElementById('companyNameR').value;
     var companyWeb = document.getElementById('companyWebR').value;
     var companyEmail = document.getElementById('companyEmailR').value;
     var companySector = document.getElementById('companySectorR').value;
     var companyTel = document.getElementById('companyTelR').value;
  
    var updateEndpointUrl = 'https://localhost:7271/api/customers/Customer/Update/' + companyId;
    var updateData = {
      companyId: parseInt(companyId),
      companyName: companyName,
      companyWeb: companyWeb,
      companyEmail: companyEmail,
      companySector: companySector,
      companyTel: parseInt(companyTel)
    };
   
    fetch(updateEndpointUrl, {
      method: 'POST',
      headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
      },
      body: JSON.stringify({
        "companyName": updateData.companyName,
        "companyWeb": updateData.companyWeb,
        "companyMail": updateData.companyEmail,
        "companyTel": updateData.companyTel,
        "companySector": updateData.companySector
      })
    })
      .then(function(response) {
      return response.json();
    })
    .then(function(data) {
      console.log('Update successful:', data);
      alert('Update successful');
              // Güncellenen bilgileri inputlara getirin
      document.getElementById('companyNameR').value = data.companyName;
      document.getElementById('companyWebR').value = data.companyWeb;
      document.getElementById('companyEmailR').value = data.companyMail;
      document.getElementById('companySectorR').value = data.companySector;
      document.getElementById('companyTelR').value = data.companyTel;
      })
      .catch(function(error) {
        console.log('Update error:', error);
        alert('Update error');
      });
  });