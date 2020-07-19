<template>
  <!-- <div class="col-4 m-2 border border-dark bg-light shadow text-center">
    <router-link :to="{ path: `/vault/${vault.id}` }" @click="setActiveVault">
      <div>
        <h3>{{vault.name}}</h3>
        <h5>{{vault.description}}</h5>
      </div>
    </router-link>
  </div>-->
  <div
    class="card my-3 mx-2 shadow"
    style="width: 450px;"
    @click="$router.push({name: 'vault-details', params: {id: vault.id}})"
  >
    <div class="row no-gutters">
      <div class="col-md-4">
        <img :src="vault.img" class="card-img" alt />
      </div>
      <div class="col-md-8">
        <div class="card-body">
          <h5 class="card-title">{{vault.name}}</h5>
          <p class="card-text">{{vault.description}}</p>
          <p class="card-text"></p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vault-component",
  methods: {
    setActiveVault() {
      this.$store.commit("setActiveVault", this.vault);
    }
  },
  props: ["vault"]
};
</script>

<style>
.card-img {
  height: 150px;
}
</style>