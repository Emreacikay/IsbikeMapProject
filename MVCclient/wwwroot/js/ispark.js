//// Fetches the Json result and returns it
//async function fetchresults(url) {
//	let response = await fetch(url);
//	let result = await response.json();
//	return result;
//}

// Converts json to geojson
async function toGeoJson(json) {
	// GeoJson'ı başlat
	let geoJson = '{ "type": "FeatureCollection", "features": [';
	let lat;
	let lon;
	let id;
	let istasyon_no;
	let adi;
	let aktif;
	let bos;
	let dolu;
	let sonbaglanti;
	let county_name;
	let rank;

	// Her eleman için
	json.forEach(element => {
		// Koordinatlarını lat ve lon içerisine al
		lat = element['lat'];
		lon = element['lon'];
		// Özelliklerini de birer değişkene ver
		id = element['Id'];
		name = element['adi'];
		active = element['aktif'];
		park_type_id = element['PARK_TYPE_ID'];
		park_type_desc = element['PARK_TYPE_DESC'];
		capacity_of_park = element['CAPACITY_OF_PARK'];
		working_time = element['WORKING_TIME'];
		county_name = element['COUNTY_NAME'];
		rank = element['rank'];
		// Sonra bunları geojson'a birer feature olarak ekle
		geoJson += '{ "type": "Feature","geometry": { "type": "Point", "coordinates":[' + lon + ',' + lat + ']},"properties": {"PARK_NAME":' + '"' + park_name + '"' + "," + '"LOCATION_NAME":' + '"' + location_name + '"' + "," + '"PARK_TYPE_ID":' + '"' + park_type_id + '"' + "," + '"PARK_TYPE_DESC":' + '"' + park_type_desc + '"' + "," + '"CAPACITY_OF_PARK":' + '"' + capacity_of_park + '"' + "," + '"WORKING_TIME":' + '"' + working_time + '"' + "," + '"COUNTY_NAME":' + '"' + county_name + '"' + "," + '"rank":' + '"' + rank + '"' + "} },";
	});
	// En son elemandan sonraki virgülü kaldır
	geoJson = geoJson.slice(0, -1);
	// GeoJson'ı kapat
	geoJson += "]}";
	// Içerisinde linebreak(yeni satır) varsa kaldır
	geoJson = geoJson.replaceAll("\r\n", "");
	// Json olarak geri çevir
	return JSON.parse(geoJson);
}


// Gets the result, converts it to geojson and prints it
//async function getAndReturnResults() {
//	let url = 'https://data.ibb.gov.tr/api/3/action/datastore_search?q=KAPALI&resource_id=f4f56e58-5210-4f17-b852-effe356a890c';
//	let response = await fetchresults(url);
//	let geoJson = await toGeoJson(response.result.records);
//	return (geoJson);
//}




