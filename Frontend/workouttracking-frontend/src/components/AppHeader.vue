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
      <!-- <div v-if="isAuthenticated" class="text-end">
        {{user.email}}
        <button type="button" class="btn btn-outline-light me-2" @click="logout">Logout</button>
      </div> -->
    </div>
  </div>
</template>

<script>
export default {
  name: "AppHeader",
  // data() {
  //   return {
  //     isAuthenticated: this.$keycloak.authenticated,
  //     user: this.$keycloak.profile,
  //   }
  // },
  // methods: {
  //   async logout() {
  //     await this.$keycloak.logout();
  //   }
  // }
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