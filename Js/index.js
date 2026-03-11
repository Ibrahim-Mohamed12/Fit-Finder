(function () {
  const backBtn = document.getElementById("backToTopFixed");
  if (!backBtn) return;

  const SHOW_AFTER = 300;

  function updateBackBtn() {
    if (window.scrollY > SHOW_AFTER) {
      backBtn.classList.remove("opacity-0", "pointer-events-none");
      backBtn.classList.add("opacity-100");
    } else {
      backBtn.classList.add("opacity-0", "pointer-events-none");
      backBtn.classList.remove("opacity-100");
    }
  }

  updateBackBtn();
  window.addEventListener("scroll", updateBackBtn, { passive: true });

  backBtn.addEventListener("click", (e) => {
    e.preventDefault();
    window.scrollTo({ top: 0, behavior: "smooth" });
  });

  window.addEventListener("pageshow", updateBackBtn);
})();

document.addEventListener("scroll", () => {
  const nav = document.getElementById("mainNav");
  if (!nav) return;

  if (window.scrollY > 10) {
    nav.classList.add("bg-black/80", "backdrop-blur-sm");
  } else {
    nav.classList.remove("bg-black/80", "backdrop-blur-sm");
  }
});

const burgerBtn = document.getElementById('burgerBtn');
const navLinks = document.getElementById('navLinks');
const ctaLinks = document.getElementById('ctaLinks');

burgerBtn.addEventListener('click', () => {
    navLinks.classList.toggle('hidden');
    ctaLinks.classList.toggle('hidden');

    navLinks.classList.add(
        'absolute','bg-black/80','w-full','left-0','top-full',
        'text-center','py-4','pt-8','space-y-3'
    );

    ctaLinks.classList.add(
        'absolute','bg-black/80','w-full','left-0','top-78.5','text-center','py-4'
    );
});


/* Exit burger menu when screen is maximized */
window.addEventListener('resize', () => {
    if (window.innerWidth >= 1024) {   // Tailwind lg breakpoint
        navLinks.classList.remove('hidden');
        ctaLinks.classList.remove('hidden');

        navLinks.classList.remove(
            'absolute','bg-black/80','w-full','left-0','top-full',
            'text-center','py-4','pt-8','space-y-3'
        );

        ctaLinks.classList.remove(
            'absolute','bg-black/80','w-full','left-0','top-78.5','text-center','py-4'
        );
    }
    else{
      navLinks.classList.add('hidden');
        ctaLinks.classList.add('hidden');

        navLinks.classList.add(
            'absolute','bg-black/80','w-full','left-0','top-full',
            'text-center','py-4','pt-8','space-y-3'
        );

        ctaLinks.classList.add(
            'absolute','bg-black/80','w-full','left-0','top-78.5','text-center','py-4'
        );
    }
});



// const stats = document.querySelectorAll(".stats");

// let current = 0;

// function jumpStats() {

//     const stat = stats[current];

//     // use tailwind's spacing-based translate instead of arbitrary value
//     stat.classList.add("-translate-y-3");

//     setTimeout(() => {
//         stat.classList.remove("-translate-y-3");
//     }, 250);

//     current = (current + 1) % stats.length;
// }

// setInterval(jumpStats, 700);

// const cards = document.querySelectorAll(".Services-Card");

// const observer = new IntersectionObserver((entries) => {
//   entries.forEach(entry => {
//     if (entry.isIntersecting) {

//       cards.forEach((card, i) => {
//         setTimeout(() => {
//           card.classList.remove("opacity-0", "translate-y-6");
//           card.classList.add("opacity-100", "translate-y-0");
//         }, i * 200);
//       });

//       observer.disconnect(); // only reveal once
//     }
//   });
// }, { threshold: 0.3 });

// cards.forEach(card => observer.observe(card));
