// ===============================
// 📌 NAVBAR SCROLL EFFECT
// ===============================
const nav = document.getElementById("mainNav");

function handleNavbarScroll() {
  if (!nav) return;

  if (window.scrollY > 10) {
    nav.classList.add("bg-black/80", "backdrop-blur-sm");
  } else {
    nav.classList.remove("bg-black/80", "backdrop-blur-sm");
  }
}

window.addEventListener("scroll", handleNavbarScroll, { passive: true });


// ===============================
// 📌 MOBILE MENU (BURGER)
// ===============================


const burgerBtn = document.getElementById("burgerBtn");
const mobileMenu = document.getElementById("mobileMenu");
const closeMenu = document.getElementById("closeMenu");

// open menu
if (burgerBtn && mobileMenu) {
  burgerBtn.addEventListener("click", () => {
    mobileMenu.classList.toggle("hidden");
    document.body.classList.add("overflow-hidden");
  });

  // close menu when clicking any link
  mobileMenu.querySelectorAll("a").forEach(link => {
    link.addEventListener("click", () => {
      mobileMenu.classList.add("hidden");
      document.body.classList.remove("overflow-hidden");
    });
  });

  // optional: close on ESC
  document.addEventListener("keydown", (e) => {
    if (e.key === "Escape") {
      mobileMenu.classList.add("hidden");
      document.body.classList.remove("overflow-hidden");
    }
  });

  document.addEventListener("click", (e) => {
    const isClickInsideMenu = mobileMenu.contains(e.target);
    const isClickOnBurger = burgerBtn.contains(e.target);

    if (!isClickInsideMenu && !isClickOnBurger && !mobileMenu.classList.contains("hidden")) {
      mobileMenu.classList.add("hidden");
      document.body.classList.remove("overflow-hidden");
    }
  });
}

// ===============================
// 📌 CLOSE MENU ON LINK CLICK
// ===============================
const mobileLinks = mobileMenu ? mobileMenu.querySelectorAll("a") : [];

mobileLinks.forEach(link => {
  link.addEventListener("click", () => {
    if (mobileMenu) mobileMenu.classList.add("hidden");
    try { isMenuOpen = false; } catch (e) {}
  });
});


// ===============================
// 📌 RESET MENU ON RESIZE
// ===============================
window.addEventListener("resize", () => {
  if (window.innerWidth >= 1024) {
    if (mobileMenu) mobileMenu.classList.add("hidden");
    isMenuOpen = false;
  }
});

document.addEventListener("scroll", () => {
  const nav = document.getElementById("mainNav");
  if (!nav) return;

  if (window.scrollY > 10) {
    nav.classList.add("bg-black/80", "backdrop-blur-sm");
  } else {
    nav.classList.remove("bg-black/80", "backdrop-blur-sm");
  }
});


// ===============================
// 📌 BACK TO TOP BUTTON
// ===============================
const backBtn = document.getElementById("backToTopFixed");

function handleBackToTop() {
  if (!backBtn) return;

  if (window.scrollY > 300) {
    backBtn.classList.remove("opacity-0", "pointer-events-none");
    backBtn.classList.add("opacity-100");
  } else {
    backBtn.classList.add("opacity-0", "pointer-events-none");
    backBtn.classList.remove("opacity-100");
  }
}

window.addEventListener("scroll", handleBackToTop, { passive: true });

if (backBtn) {
  backBtn.addEventListener("click", (e) => {
    e.preventDefault();
    window.scrollTo({
      top: 0,
      behavior: "smooth"
    });
  });
}


// ===============================
// 📌 INITIAL LOAD FIXES
// ===============================
window.addEventListener("load", () => {
  handleNavbarScroll();
  handleBackToTop();
});

// ===============================
// 📌 FADE-UP STAGGER SEQUENCE ON LOAD
// ===============================
(function(){
  function runFadeUpSequence() {
    const title = document.querySelector('.fade-up[data-animate="title"]');
    const cards = document.querySelectorAll('#mainBody .grid .fade-up');
    let delay = 120;
    if (title) {
      setTimeout(() => title.classList.add('show'), delay);
      delay += 220;
    }
    cards.forEach((el, i) => {
      setTimeout(() => el.classList.add('show'), delay + i * 180);
    });
  }

  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', runFadeUpSequence);
  } else {
    runFadeUpSequence();
  }
})();


// ===============================
// 📌 SCROLL-REVEAL (IntersectionObserver)
// Reveals any remaining .fade-up elements when scrolled into view
// ===============================
(function(){
  function initScrollReveal() {
    const els = Array.from(document.querySelectorAll('.fade-up')).filter(e => !e.classList.contains('show'));
    if (!els.length) return;

    const io = new IntersectionObserver((entries, observer) => {
      entries.forEach(entry => {
        if (entry.isIntersecting) {
          entry.target.classList.add('show');
          observer.unobserve(entry.target);
        }
      });
    }, { root: null, rootMargin: '0px 0px -10% 0px', threshold: 0.12 });

    els.forEach(el => io.observe(el));
  }

  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initScrollReveal);
  } else {
    initScrollReveal();
  }
})();


// ===============================
// 📌 CARD-BY-CARD REVEAL FOR GRID SECTIONS
// Reveals each `.group` card in target grids one-by-one when grid enters viewport
// ===============================
(function(){
  function injectCardRevealCSS(){
    if (document.getElementById('card-reveal-styles')) return;
    const s = document.createElement('style');
    s.id = 'card-reveal-styles';
    s.textContent = '\n.reveal-card{opacity:0;transform:translateY(20px);transition:opacity .5s cubic-bezier(.22,.9,.33,1),transform .5s cubic-bezier(.22,.9,.33,1);will-change:opacity,transform}\n.reveal-card.show{opacity:1;transform:translateY(0)}\n';
    document.head.appendChild(s);
  }

  function findTargetGrids(){
    const gridsSet = new Set();
    const headings = Array.from(document.querySelectorAll('h2'));

    // Look for known section headings to target explicitly
    const patterns = [/Top\s*Gyms/i, /Smart\s*Offers|Offers/i];
    patterns.forEach(pat => {
      const h = headings.find(h2 => pat.test(h2.textContent));
      if (h) {
        const sec = h.closest('section') || h.parentElement;
        const grid = sec && sec.querySelector('.grid');
        if (grid) gridsSet.add(grid);
      }
    });

    // Also include any grid that looks like a card grid (has multiple .group children)
    document.querySelectorAll('.grid').forEach(g => {
      if (g.querySelectorAll('.group').length >= 1) gridsSet.add(g);
    });

    return Array.from(gridsSet);
  }

  function initCardByCard(){
    injectCardRevealCSS();
    const grids = findTargetGrids();
    if (!grids.length) return;

    grids.forEach(grid => {
      const cards = Array.from(grid.querySelectorAll('.group'));
      if (!cards.length) return;

      // ensure cards start hidden (in case HTML doesn't have classes)
      cards.forEach(c => c.classList.add('reveal-card'));

      const io = new IntersectionObserver((entries, obs) => {
        entries.forEach(entry => {
          if (entry.isIntersecting) {
            cards.forEach((card, i) => {
              setTimeout(() => card.classList.add('show'), i * 200);
            });
            obs.unobserve(entry.target);
          }
        });
      }, { root: null, rootMargin: '0px 0px -10% 0px', threshold: 1.5 });

      io.observe(grid);
    });
  }

  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', initCardByCard);
  } else {
    initCardByCard();
  }
})();


// const modal = document.getElementById("gymModalOverlay");
// const closeBtn = document.getElementById("closeGymModal");

// // open modal function
// function openGymModal(name, location, image) {
//     document.getElementById("modalGymName").innerText = name;
//     document.getElementById("modalGymLocation").innerText = location;
//     document.getElementById("modalGymImage").src = image;

//     modal.classList.remove("hidden");
//     modal.classList.add("flex");
// }

// // close modal
// closeBtn.addEventListener("click", () => {
//     modal.classList.add("hidden");
//     modal.classList.remove("flex");
// });

// // close on outside click
// modal.addEventListener("click", (e) => {
//     if (e.target === modal) {
//         modal.classList.add("hidden");
//         modal.classList.remove("flex");
//     }
// });

const sidebar = document.getElementById("sidebar");
const overlay = document.getElementById("overlay");
const texts = document.querySelectorAll(".sidebar-text");

function toggleSidebar() {
  if (window.innerWidth < 768) {
    // 📱 MOBILE → slide sidebar
    sidebar.classList.toggle("-translate-x-full");
    overlay.classList.toggle("hidden");
  } else {
    // 💻 DESKTOP → collapse sidebar
    sidebar.classList.toggle("w-80");
    sidebar.classList.toggle("w-20");

    texts.forEach(text => text.classList.toggle("hidden"));
  }
}

// close on overlay click (mobile only)
overlay.onclick = () => {
  sidebar.classList.add("-translate-x-full");
  overlay.classList.add("hidden");
};