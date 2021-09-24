const gulp = require("gulp");
const pug = require("gulp-pug");

const { src, dest } = gulp;

gulp.task("build", () => src("./src/*.pug").pipe(pug()).pipe(dest("./dist")));
