# Project: Mars Rover Hub

## Description

This project was created as part of Softwires software engineering apprenticeship bootcamp. The goal is to design a platform which displays interesting uses of [NASA's open APIs](https://api.nasa.gov/) and information related to the currently active mars rovers. This project was developed from the ASP.net Core web application framework.

## Build Requirements

.NET Framework 5.0
<details>
	<summary>NASA API key</summary>
	An API key must be placed within a .env file located at the root of the application, this should follow the below format
	```
    API_KEY=DEMO_KEY
    ```
    To generate a new API key head [here](https://api.nasa.gov/) and click generate new key, enter a valid email and the key will be sent. This should replace the DEMO_KEY value above to ensure the application remains functional after a few requests.
</details>