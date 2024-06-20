import { createRouter, createWebHistory } from 'vue-router'
import HomePage from '@/views/HomePage'
import StatsPage from '@/views/StatsPage'
import WorkoutComponent from "@/components/Workout";
import { authGuard } from '@auth0/auth0-vue'

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomePage,
    beforeEnter: authGuard
  },
  {
    path: '/stats',
    name: 'StatsPage',
    component: StatsPage,
    beforeEnter: authGuard
  },
  {
    path: '/workout/:id',
    name: 'WorkoutComponent',
    component: WorkoutComponent

  }
]

const router = createRouter({
  history: createWebHistory(),
  routes: routes
})

export default router
