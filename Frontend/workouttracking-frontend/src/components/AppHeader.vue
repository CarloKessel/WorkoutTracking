<template>
  <div class="container">
    <div class="d-flex flex-wrap align-items-center justify-content-center justify-content-lg-start">
      <ul class="nav col-12 col-lg-auto me-lg-auto mb-2 justify-content-center mb-md-0">
        <li>
          <router-link to="/" class="nav-link px-2">Workouts</router-link>
        </li>
        <li>
          <router-link to="/stats" class="nav-link px-2">Stats</router-link>
        </li>
      </ul>
      <div v-if="!isAuthenticated" class="text-end">
        <button type="button" class="btn btn-outline-light me-2" @click="login">Login</button>
      </div>
      <div v-else>
        {{user.email}}
        <button type="button" class="btn btn-outline-light me-2" @click="deleteAccount">Delete account</button>
        <button type="button" class="btn btn-outline-light me-2" @click="logout">Logout</button>
      </div>
    </div>
  </div>
</template>

<script>
  import { useAuth0 } from '@auth0/auth0-vue';
  import axios from 'axios';
  export default {
    name: "AppHeader",
    setup() {
      const { logout, loginWithRedirect, user, isAuthenticated } = useAuth0();

      async function getAuth0Token() {
        const response = await axios.post(`https://${process.env.VUE_APP_AUTH0_DOMAIN}/oauth/token`, 
        {
            client_id: process.env.VUE_APP_AUTH0_APIEA_CLIENT_ID,
            client_secret: process.env.VUE_APP_AUTH0_APIEA_CLIENT_SECRET,
            audience: `https://${process.env.VUE_APP_AUTH0_DOMAIN}/api/v2/`,
            grant_type: "client_credentials"
        });
        return response.data.access_token;
      }

      return {
        login: () => {
          loginWithRedirect();
        },
        logout: () => {
          logout({ logoutParams: { returnTo: window.location.origin } });
        },
        deleteAccount: async () => {   
          const access_token = await getAuth0Token();
          const deleteconfig = {
            headers: {
              'Authorization': 'Bearer ' + access_token
            }
          };
          
          const deletedSucces = await axios.delete(`https://${process.env.VUE_APP_AUTH0_DOMAIN}/api/v2/users/` + user.value.sub, deleteconfig)
            .then(async (res) => {
              return res;
            })
            .catch(async (error) => {
              console.log(error);
            });
          
          if (deletedSucces.status === 204) {
            logout({ logoutParams: { returnTo: window.location.origin } });
          }
        },
        user,
        isAuthenticated
      };
    }
  };
</script>

<style scoped>
li a {
  color: white !important;
  text-decoration: none !important;
}

li a:hover {
  color: #34D2C1 !important;
}

li a.router-link-active {
  color: #34D2C1 !important;
}
</style>