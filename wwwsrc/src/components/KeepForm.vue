<template>
  <div class="keepForm">
    <form @submit.prevent="addKeep">
      <div class="form-group">
        <label for="make">Title</label>
        <input
          v-model="newKeep.name"
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
          v-model="newKeep.description"
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
          v-model="newKeep.img"
          type="text"
          name="imgUrl"
          class="form-control"
          placeholder="Enter img url...."
          required
        />
      </div>
      <div class="form-group">
        <div class="form-check">
          <input
            v-model="newKeep.isPrivate"
            class="form-check-input"
            type="checkbox"
            value
            id="defaultCheck1"
          />
          <label class="form-check-label" for="defaultCheck1">Private?</label>
        </div>
      </div>
      <button type="submit" class="btn btn-primary">Add Keep</button>
    </form>
  </div>
</template>

<script>
export default {
  name: "keepForm",
  data() {
    return {
      newKeep: {
        isPrivate: false
      }
    };
  },
  methods: {
    addKeep() {
      this.$store.dispatch("addKeep", { ...this.newKeep });
      this.newKeep = {
        isPrivate: false
      };
    }
  }
};
</script>

<style>
</style>