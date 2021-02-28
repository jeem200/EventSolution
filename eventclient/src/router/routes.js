import Home from '../modules/Home.vue'
import Vendor from '../modules/Vendor/Vendor.vue'
import Customer from '../modules/Customer/Customer.vue'

const routes = [
    {
      path: '/',
      name: 'Home',
      component: Home
    },
    {
      path: '/vendor',
      name: 'Vendor',
      component:Vendor
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
     // component: () => import(/* webpackChunkName: "about" */ '../modules/About.vue')
    },
    {
        path:'/customer',
        name:'Customer',
        component:Customer
    }
  ]


  export default routes