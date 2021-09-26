const gulp = require("gulp");
const pug = require("gulp-pug");
const concat = require("gulp-concat");
const cleanCSS = require("gulp-clean-css");
const del = require("del");

const { src, dest } = gulp;

gulp.task("build", (done) => {
  gulp.series("clean", "pug")(done);
});

gulp.task("pug", () => src("./src/*.pug").pipe(pug()).pipe(dest("./dist")));

gulp.task("css", () =>
  src("./**/*.css")
    .pipe(cleanCSS())
    .pipe(concat("index.css"))
    .pipe(dest("./dist"))
);

gulp.task("clean", () => del("./dist"));
