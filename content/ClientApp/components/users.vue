<template>
    <div>
        <h1>Users</h1>

        <p>This component demonstrates fetching data from the server.</p>

        <div v-if="!users" class="text-center">
            <p><em>Loading...</em></p>
            <h1><icon icon="spinner" pulse/></h1>            
        </div>

        <table class="table" v-if="users">
            <thead  class="bg-dark text-white">
                <tr>
                    <th>Name</th>
                    <th>Age</th>
                    <th>Address</th>
                    <th><a><icon icon="plus" v-on:click="addUser"></icon></a></th>
                </tr>
            </thead>
            <tbody>
                <tr :class="index % 2 == 0 ? 'bg-white' : 'bg-light'" v-for="(item, index) in users" :key="item.id">
                    <td>{{ item.name }}</td>
                    <td>{{ item.age }}</td>
                    <td>{{ item.address }}</td>
                    <td><a><icon icon="edit" v-on:click="editUser(item, index)"></icon></a></td>
                </tr>
            </tbody>
        </table>
        <div v-if="dude">
            <user v-on:userChange="receiveEdits" v-on:cancelChange="cancelEdits" v-bind:initUser="dude"></user>
        </div>
    </div>
</template>

<script>
import User from './user'


export default {
    components:{
        "user": User
    },
    data() {
        return {
            users: null,
            dude: null,
            editIndex: null
        }
    },
    methods: {
        editUser: function(item, index){
            this.dude = Object.assign({}, item);
            this.editIndex = index;
        },
        addUser: function(){
            this.dude = {id: 0, name: "", age: "", address:""};
            this.editIndex = -1;
        },
        cancelEdits: function () {
            this.dude = null;
            this.editIndex = null;
        },
        receiveEdits: async function (user) {
            console.log('saving');
            if(this.editIndex === -1)
            {
                var data = JSON.stringify(user);
                try {
                    let response = await this.$http.put('/api/SampleData/AddUser', data, {
                        headers:{
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        }
                    })
                    this.users.push(user);
                } catch (error) {
                    console.log(error)
                }
            }
            else{
                var data = JSON.stringify(user);
                try {
                    let response = await this.$http.put('/api/SampleData/SaveUser', data, {
                        headers:{
                            'Accept': 'application/json',
                            'Content-Type': 'application/json'
                        }
                    })
                    this.users[this.editIndex] = user;
                    
                } catch (error) {
                    console.log(error)
                }
            }
            this.editIndex = null;
            this.dude = null;
        }
    },
    async created() {
        // ES2017 async/await syntax via babel-plugin-transform-async-to-generator
        // TypeScript can also transpile async/await down to ES5
        try {
            let response = await this.$http.get('/api/SampleData/Users')
            console.log(response.data);
            this.users = response.data;
        } catch (error) {
            console.log(error)
        }
        // Old promise-based approach
        //this.$http
        //    .get('/api/SampleData/WeatherForecasts')
        //    .then(response => {
        //        console.log(response.data)
        //        this.forecasts = response.data
        //    })
        //    .catch((error) => console.log(error))*/
    }
}
</script>

<style>
</style>
