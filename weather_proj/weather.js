const apiKey = "a54fbb2d03f7f2626e55c0a7e9ce4d14";
const apiUrl = "https://api.openweathermap.org/data/2.5/weather?&units=metric&q=";
const searchBox = document.querySelector(".search input");
const searchBtn = document.querySelector(".search button");
const weatherIcon = document.querySelector(".weather-icon");
const errorDiv = document.querySelector(".error");
const weatherDiv = document.querySelector(".weather");
const body = document.body;

async function checkWeather(city) {
    const response = await fetch(apiUrl + city + `&appid=${apiKey}`);

    if(response.status == 404) {
        errorDiv.style.display = "block";
        weatherDiv.style.display = "none";
    } else {
        errorDiv.style.display = "none";
        weatherDiv.style.display = "block";

        if (response.ok) {
            const data = await response.json();
            console.log(data);
            document.querySelector(".city").innerHTML = data.name;
            document.querySelector(".temp").innerHTML = Math.round(data.main.temp) + "°C";
            document.querySelector(".humidity").innerHTML = data.main.humidity + "%";
            document.querySelector(".wind").innerHTML = data.wind.speed + " km/h";
            switch (data.weather[0].main) {
                case "Clouds":
                    weatherIcon.src = "imagini/clouds.png";
                    document.body.style.backgroundImage = "url('imagini/clouds.jpg')";
                    break;
                case "Clear":
                    weatherIcon.src = "imagini/clear.png";
                    document.body.style.backgroundImage = "url('imagini/sun.jpg')";
                    break;
                case "Rain":
                    weatherIcon.src = "imagini/rain.png";
                    document.body.style.backgroundImage = "url('imagini/rainy-pictures-2.jpg')";
                    
                    break;
                case "Drizzle":
                    weatherIcon.src = "imagini/drizzle.png";
                    document.body.style.backgroundImage = "url('imagini/rainy-pictures-2.jpg')";
                    break;
                case "Mist":
                    weatherIcon.src = "imagini/mist.png";
                    document.body.style.backgroundImage = "url('imagini/mist.jpg)";
                    break;
                default:
                    weatherIcon.src = ""; 
                    document.body.style.backgroundImage = "url('clouds-background.jpg')";
            }
        } else {
            console.error('Network response was not ok.');
        }
    }
}

searchBtn.addEventListener("click", () => {
    checkWeather(searchBox.value);
});