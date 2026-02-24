const BASE_URL =
  "https://api.open-meteo.com/v1/forecast?latitude=20.2961&longitude=85.8245&current_weather=true";

// Function to display formatted weather report
const displayWeather = (weather) => {
  console.log("\n🌤 WEATHER REPORT");
  console.log("----------------------------------");
  console.log(`Temperature     : ${weather.temperature}°C`);
  console.log(`Wind Speed      : ${weather.windspeed} km/h`);
  console.log(`Wind Direction  : ${weather.winddirection}°`);
  console.log(`Time            : ${weather.time}`);
  console.log("----------------------------------\n");
};

// Using Promises
const fetchWeatherWithPromise = () => {
  fetch(BASE_URL)
    .then((response) => {
      if (!response.ok) {
        throw new Error("Failed to fetch weather data");
      }
      return response.json();
    })
    .then((data) => {
      console.log(" Using Promise Version");
      displayWeather(data.current_weather);
    })
    .catch((error) => {
      console.error(` Promise Error: ${error.message}`);
    });
};

// using async/await

const fetchWeatherAsync = async () => {
  try {
    const response = await fetch(BASE_URL);

    if (!response.ok) {
      throw new Error("Failed to fetch weather data");
    }

    const data = await response.json();

    console.log(" Using Async/Await Version");
    displayWeather(data.current_weather);
  } catch (error) {
    console.error(` Async/Await Error: ${error.message}`);
  }
};

fetchWeatherWithPromise();
fetchWeatherAsync();