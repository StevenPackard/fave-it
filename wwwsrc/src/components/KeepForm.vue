<template>
  <form class="mt-3" @submit.prevent="addVault">
    <div class="form-row">
      <div class="col">
        <input type="text" v-model="newVault.name" class="form-control" placeholder="Vault Name" />
      </div>
      <div class="col">
        <input
          type="text"
          v-model="newVault.description"
          class="form-control"
          placeholder="Vault Description"
        />
      </div>
      <button class="btn btn-success" type="submit">Add Vault</button>
    </div>
  </form>
</template>

<script>
export default {
  name: "keep-form",
  data() {
    return {
      newVault: {}
    };
  },
  methods: {
    addVault() {
      this.$store.dispatch("addVault", { ...this.newVault });
      this.newVault = {};
    }
  }
};
</script>

<style>
</style>