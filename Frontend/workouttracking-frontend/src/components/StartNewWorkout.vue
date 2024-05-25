<template>
  <form class="startNewWorkout" v-on:submit.prevent="startWorkout">
    <div class="mb-3 col-2">
      <input id="name" v-model="form.name" class="form-control input-add-workout" placeholder="Workout Name" type="text">
    </div>
    <button :disabled="!formIsValid" class="btn btn-lg btn-add-workout" type="submit">
      Start New Workout
    </button>
  </form>
</template>

<script>
import axios from 'axios';

export default {
  name: 'StartNewWorkout',
  data() {
    return {
      form: {
        name: ''
      }
    }
  },
  computed: {
    formIsValid() {
      return !!this.form.name
    }
  },
  methods: {
    async startWorkout() {
      if (this.formIsValid) {
        const token = await this.$auth0.getAccessTokenSilently();
        const config = {
          headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Origin': '*',
            'Authorization': 'Bearer ' + token
          }
        };

        await axios.post(`${process.env.VUE_APP_API_GATEWAY}/write-api/workout`, {name: this.form.name, userEmail: this.$auth0.user.value.email}, config)
            .then(async (res) => {
              this.form.name = '';
              console.log(res);
              //Go to overview of workout. give the location with it and make axios request with this link to get workout info. then make axios request for all exercises
              // await router.push('/workout/' + res.data.id);
              // await this.$snackbar.add({
              //   type: 'info',
              //   title: 'Workout added!'
              // });
            })
            .catch(async (error) => {
              console.log(error);
              // await this.$snackbar.add({
              //   type: 'error',
              //   title: 'Error!',
              //   text: error.response.data
              // });
            });
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">
  @media only screen and (max-width: 600px) {
    .input-add-workout {
      width: auto;
    }
  }     

  #name::-moz-placeholder{
    color: #958C8C;
  }

  .btn-add-workout {
    color: white;
    border: none;
    background: linear-gradient(270deg, #5782FF 0%, #34D2C1 42.1%, #34D2C1 100%);
    padding: 5px 50px;
    border-radius: 55px;
    font-size: 18px;
  }

</style>
