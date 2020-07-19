<template>
  <div class="vaultForm">
    <form @submit.prevent="addVault">
      <div class="form-group">
        <label for="make">Title</label>
        <input
          v-model="newVault.name"
          type="text"
          name="title"
          class="form-control"
          placeholder="Enter title...."
          required
        />
      </div>
      <div class="form-group">
        <label for="model">Description</label>
        <input
          v-model="newVault.description"
          type="text"
          name="description"
          class="form-control"
          placeholder="Enter description...."
          required
        />
      </div>
      <div class="form-group">
        <label for="year">Image URL</label>
        <input
          v-model="newVault.img"
          type="text"
          name="imgUrl"
          class="form-control"
          placeholder="Enter img url...."
        />
      </div>

      <button type="submit" class="btn btn-primary">Add Vault</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "vault-form",
  data() {
    return {
      newVault: {
        userImg: this.$auth.user.picture
      }
    };
  },
  methods: {
    addVault() {
      this.$store.dispatch("addVault", { ...this.newVault });
      this.newVault = {
        userImg: this.$auth.user.picture
      };
    }
  }
};
</script>

<style>
</style>