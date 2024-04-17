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
      domain: "dev-vvr65zntgft7vbt4.us.auth0.com",
      clientId: "qKzrAnxuI5xqCPpgT4ZGPO7Jn3IpVpE8",
      useRefreshTokens: true,
      cacheLocation: "localstorage",
      authorizationParams: {
        redirect_uri: window.location.origin
      }
    })
);
app.use(router);
app.mount('#app');
