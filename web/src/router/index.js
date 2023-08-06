import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from '../components/comm/Layout.vue'
import NavItem from '../components/comm/NavItem.vue'
import Home from '../components/comm/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView,
    redirect:'/Home',
    children: [
      {
        path: '/NavItem',
        name: 'navItem',
        component: NavItem
      },
      {
        path:'/Home',
        name:'home',
        component:Home
      }
    ]
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
