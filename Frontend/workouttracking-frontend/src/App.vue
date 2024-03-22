<script>
  import AppHeader from "@/components/AppHeader";
  import AppFooter from "@/components/AppFooter";

  export default {
    name: 'App',
    components: {
      AppHeader,
      AppFooter,
    },
  }
</script>

<template>
  <main class="container-fluid">
    <AppHeader/>
    <router-view/>
    <AppFooter/>
    <teleport to="body">
      <!-- <vue3-snackbar bottom right :duration="4000"></vue3-snackbar> -->
    </teleport>
  </main>
</template>

<style lang="scss">
html, body {
  background-color: #2D2B41 !important;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  color: #ffffff;
}

.form-control {
  background: none !important;
  border-color: #34D2C1 !important;
  color: #fff !important;
  border-radius: 25px !important;
}

.form-control:focus {
  background: none !important;
  color: #fff !important;
}
</style>

