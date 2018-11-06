<template>
    <div class="user-card">
        <div>
            <table>
                <tr>
                    <td>Name:</td>
                    <td><input v-model="initUser.name" /></td>
                </tr>
                <tr>
                    <td>Age:</td>
                    <td><input v-model="initUser.age" /></td>
                </tr>
                <tr>
                    <td>Address:</td>
                    <td><input v-model="initUser.address" /></td>
                </tr>
            </table>
        </div>
        <div>
            <button type="button" @click="emitChanges">Save Changes</button>
            <button type="button" @click="cancelChanges">Cancel</button>
        </div>
    </div>
</template>

<script>
export default {
    props:['initUser'],
    methods: {
        emitChanges: function(){
            this.$emit('userChange', this.initUser);
        },
        cancelChanges: function () {
            this.$emit('cancelChange');
        }
    }


}
</script>

<style scoped>
    .user-card{
        padding: 0 20px;
        width:300px;
        display:flex;
        flex-direction: column;
        align-items:center;
    }

</style>
