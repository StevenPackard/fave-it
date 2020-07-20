<template>
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-12 text-center">
        <h1>My Keeps</h1>
      </div>
    </div>
    <div class="row">
      <div class="col text-center">
        <button
          class="btn btn-outline-primary"
          @click="showKeepForm = !showKeepForm"
        >
          New Keep
        </button>
      </div>
      <div class="col-12" v-if="showKeepForm">
        <keepForm />
      </div>
    </div>

    <div class="row justify-content-center mt-2" v-if="showPrivate">
      <div class="col-10 text-center">
        <button
          class="btn btn-outline-primary"
          @click="showPrivate = !showPrivate"
        >
          Show All Keeps
        </button>
      </div>
      <div class="card-columns">
        <keep
          class="mx-2 my-2"
          v-for="keep in privateKeeps"
          :key="keep.id"
          :keep="keep"
        />
      </div>
    </div>
    <div class="row justify-content-center mt-5" v-if="keeps.length < 1">
      <div class="col-9 text-center">
        <h3>
          You dont have any keeps yet. Add a new Keep to share with others or to
          have just for yourself.
        </h3>
      </div>
    </div>
    <div class="row justify-content-center mt-2" v-if="!showPrivate">
      <div class="col-10 text-center" v-if="privateKeeps.length > 0">
        <button
          class="btn btn-outline-primary"
          @click="showPrivate = !showPrivate"
        >
          Show Private Keeps
        </button>
      </div>

      <div class="card-columns">
        <keep class v-for="keep in keeps" :key="keep.id" :keep="keep" />
      </div>
    </div>
  </div>
</template>

<script>
import keep from "../components/KeepComponent";
import keepForm from "../components/KeepForm";
export default {
  name: "keeps",
  data() {
    return {
      showKeepForm: false,
      showPrivate: false,
    };
  },
  mounted() {
    this.$store.dispatch("getMyKeeps");
  },
  computed: {
    privateKeeps() {
      return this.$store.state.KeepsStore.myKeeps.filter(
        (k) => k.isPrivate == true
      );
    },
    keeps() {
      return this.$store.state.KeepsStore.myKeeps;
    },
  },
  components: {
    keep,
    keepForm,
  },
};
</script>

<style></style>
