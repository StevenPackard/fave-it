<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <router-link class="navbar-brand" :to="{ name: 'home' }">
      <img class="nav-img" src="../assets/keepr.png" />
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item" :class="{ active: $route.name == 'home' }">
          <router-link :to="{ name: 'home' }" class="nav-link">Home</router-link>
        </li>
        <li
          class="nav-item"
          v-if="$auth.isAuthenticated"
          :class="{ active: $route.name == 'vaults' }"
        >
          <router-link class="nav-link" :to="{ name: 'vaults' }">My Vaults</router-link>
        </li>
        <li class="nav-item" :class="{ active: $route.name == 'keeps' }">
          <router-link :to="{ name: 'keeps' }" class="nav-link">My Keeps</router-link>
        </li>
      </ul>
      <span class="navbar-text">
        <button class="btn btn-success" @click="login" v-if="!$auth.isAuthenticated">Login</button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      this.$store.dispatch("resetBearer");
      await this.$auth.logout({ returnTo: window.location.origin });
    }
  }
};
</script>

<style>
.nav-img {
  width: 100px;
  height: 90px;
}
</style>
