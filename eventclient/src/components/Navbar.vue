<template>
  <nav>
        <v-app-bar app  fixed color="grey lighten-4" elevation="0">
            <v-app-bar-nav-icon @click.stop="sidebarMenu = !sidebarMenu"></v-app-bar-nav-icon>
            <v-spacer></v-spacer>
             <v-btn color="" outlined >
                <span>Sign Out</span>
                <v-icon right>exit_to_app</v-icon>
              </v-btn>
        </v-app-bar>
    <!-- <v-toolbar  app>
      <v-toolbar-side-icon @click="drawer = !drawer" class="grey--text"></v-toolbar-side-icon>
      <v-toolbar-title class="text-uppercase grey--text">
        <span class="font-weight-light">Todo</span>
        <span>Ninja</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn flat color="grey">
        <span>Sign Out</span>
        <v-icon right>exit_to_app</v-icon>
      </v-btn>
    </v-toolbar> -->
    <v-navigation-drawer 
      v-model="sidebarMenu" 
      app
      color="grey darken-4"
      dark
      floating
      :permanent="sidebarMenu"
      
    >
        <v-list-item>
          <v-list-item-content>
            <v-list-item-title class="title">
              Evento
            </v-list-item-title>
            <v-list-item-subtitle>
              
            </v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>

        <v-divider></v-divider>

        <v-list
          dense
          nav
          color="white--text"
        >
          <v-list-item
            v-for="item in items"
            :key="item.title"
            link
            router :to="item.route"
          >
            <v-list-item-icon>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-icon>

            <v-list-item-content>
              <v-list-item-title>{{ item.text }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
      </v-list>
    </v-navigation-drawer>

  </nav>
</template>

<script>
export default {
  data() {
    return {
      sidebarMenu: false,
      items: [
        { icon: 'dashboard', text: 'Dashboard', route: '/' },
        { icon: 'folder', text: 'Vendors', route: '/vendor' },
        { icon: 'person', text: 'Customers', route: '/customer' },
      ],
           selectedItem: 1,
    }
  }
}
</script>

<style>
</style>