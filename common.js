// common.js
//function GetCityByID() {
//    debugger;
//    var select = document.getElementById('SelectedState');
//    stateId = @Model.State;
//    var cityDropdown = document.getElementById('cityDropdown');
//    cityDropdown.innerHTML = '';

//    if (stateId) {
//        $.ajax({
//            url: `/Employee/GetCitiesById?StateID=${stateId}`,
//            type: 'GET',
//            dataType: 'json',
//            success: function (cities) {
//                cities.forEach(city => {
//                    var option = document.createElement('option');
//                    option.value = city.CityID;
//                    option.innerText = city.CityName;
//                    cityDropdown.appendChild(option);
//                });
//                if (Model && Model.CityID) {
//                    k1();
//                } else {

//                }
//            },
//            error: function (xhr, status, error) {
//                console.error('Error:', error);
//            }
//        });
//    }
//}

//function k1() {
//    var cityDropdown = document.getElementById('cityDropdown');
//    for (var i = 0; i < cityDropdown.length; i++) {
//        if (cityDropdown[i].value == @Model.CityID) {
//            console.log(cityDropdown[i].value);
//            cityDropdown[i].selected = true;
//            break;
//        }
//    }
//}
