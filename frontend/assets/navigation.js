const hamburgerBtn = document.querySelector('.hamburger')
if(hamburgerBtn){
    hamburgerBtn.addEventListener('click',()=>{
        document.querySelector('.navigation').classList.toggle('is-open')
    })
}