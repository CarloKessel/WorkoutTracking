import { createApp } from 'vue';
import { createAuth0 } from '@auth0/auth0-vue';
import App from './App.vue';
import './registerServiceWorker';
import router from './router';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

const app = createApp(App);
app.use(
    createAuth0({
      domain: process.env.VUE_APP_AUTH0_DOMAIN,
      clientId: process.env.VUE_APP_AUTH0_CLIENT_ID,
      useRefreshTokens: true,
      cacheLocation: "localstorage",
      authorizationParams: {
        redirect_uri: window.location.origin,
        audience: process.env.VUE_APP_API_GATEWAY,
      }
    })
);

app.use(router);
app.mount('#app');
