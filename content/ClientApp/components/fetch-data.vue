﻿<template>
    <div>
        <h1>Weather forecast</h1>

        <p>This component demonstrates fetching data from the server.</p>

        <div v-if="!forecasts" class="text-center">
            <p><em>Loading...</em></p>
            <h1><icon icon="spinner" pulse/></h1>            
        </div>

        <table class="table" v-if="forecasts">
            <thead  class="bg-dark text-white">
                <tr>
                    <th>Date</th>
                    <th>Temp. (C)</th>
                    <th>Temp. (F)</th>
                    <th>Summary</th>
                </tr>
            </thead>
            <tbody>
                <tr :class="index % 2 == 0 ? 'bg-white' : 'bg-light'" v-for="(forecast, index) in forecasts" :key="index">
                    <td>{{ forecast.dateFormatted }}</td>
                    <td>{{ forecast.temperatureC }}</td>
                    <td>{{ forecast.temperatureF }}</td>
                    <td>{{ forecast.summary }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
export default {
    data() {
        return {
            forecasts: null
        }
    },

    methods: {
    },

    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        try {
            let response = await this.$http.get('/api/SampleData/WeatherForecasts')
            console.log(response.data);
            this.forecasts = response.data;
        } catch (error) {
            console.log(error)
        }
    }
}
</script>

<style>
</style>