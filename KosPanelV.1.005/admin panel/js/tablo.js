
// Tabloya verileri eklemek için kullanılacak HTML elementinin ID'si
var tableId = 'tablo';

// HTTP isteği için kullanılacak endpoint URL'si
var endpointUrl = 'https://localhost:7271/api/customers/';

// Tabloya verileri aktaran fonksiyon
function populateTable(data) {
  var table = document.getElementById(tableId);

  data.sort((a, b) => b.id - a.id);

  // Verileri tabloya ekle
  var VERİLER = Object.keys(data[0]); // Verilerin olduğu diziden başlıkları çek
  

// HTTP GET isteği gönderen fonksiyon
function fetchData() {
  fetch(endpointUrl , {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + localStorage.getItem('token')
    },
  })
    .then(function (response) {
      return response.json();
    })
    .then(function (data) {
      populateTable(data);
    })
    .catch(function (error) {
      console.log('Hata oluştu: ' + error);
    });
}
}