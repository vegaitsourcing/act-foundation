const gulp = require("gulp");
const pug = require("gulp-pug");

const { src, dest } = gulp;

gulp.task("build", (done) => {
  gulp.parallel("pug", "css")(done);
});

gulp.task("pug", () => src("./src/*.pug").pipe(pug()).pipe(dest("./dist")));

gulp.task("css", () => src("./index.css").pipe(dest("./dist")));
