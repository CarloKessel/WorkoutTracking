import { createRouter, createWebHashHistory } from 'vue-router'
import HomePage from '@/views/HomePage'
import StatsPage from '@/views/StatsPage'


const routes = [
  {
    path: '/',
    name: 'home',
    component: HomePage
  },
  {
    path: '/stats',
    name: 'StatsPage',
    component: StatsPage
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
