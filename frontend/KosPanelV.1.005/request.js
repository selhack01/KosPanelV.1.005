// Tabloya verileri eklemek için kullanılacak HTML elementinin ID'si
var tableId = 'myTable';

// HTTP isteği için kullanılacak endpoint URL'si
var endpointUrl = 'https://localhost:7176/api/Admin/GetCompany';

// Tabloya verileri aktaran fonksiyon
function populateTable(data) {
  var table = document.getElementById(tableId);

// Tabloya başlık satırını ekle
var headerRow = table.insertRow();
var headers = ['İD', 'İSİM', 'WEB', 'EMAİL', 'ADRES', 'TEL', 'KAYIT TARİHİ', 'SEKTÖR']; // Başlık dizisi
for (var i = 0; i < headers.length; i++) {
  var headerCell = document.createElement('th');
  headerCell.innerHTML = headers[i];
  headerRow.appendChild(headerCell);
}


  // Verileri tabloya ekle
  var VERİLER = Object.keys(data[0]); // Verilerin olduğu diziden başlıkları çek

  for (var j = 0; j < data.length; j++) {
    var row = table.insertRow();
    for (var k = 0; k < VERİLER.length; k++) {
      var cell = row.insertCell();
      cell.innerHTML = data[j][VERİLER[k]];
    }
  }
}

// HTTP GET isteği gönderen fonksiyon
function fetchData() {
  fetch(endpointUrl)
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

// Verileri çek ve tabloya aktar
fetchData();