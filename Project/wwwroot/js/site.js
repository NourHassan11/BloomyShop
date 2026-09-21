// ============================================================
//  BLOOMY SHOP — Site JavaScript
//  Premium Floral E-Commerce Interactions
// ============================================================

(function () {
    'use strict';

    // ── Scroll-aware header shadow ──────────────────────────
    var header = document.querySelector('.bloomy-header');
    if (header) {
        var onScroll = function () {
            if (window.scrollY > 20) {
                header.classList.add('scrolled');
            } else {
                header.classList.remove('scrolled');
            }
        };
        window.addEventListener('scroll', onScroll, { passive: true });
        onScroll(); // Run on load
    }

    // ── Hero Ken Burns effect trigger ───────────────────────
    var hero = document.querySelector('.bloomy-hero');
    if (hero) {
        // Small delay ensures CSS transition starts after paint
        setTimeout(function () { hero.classList.add('loaded'); }, 100);
    }

    // ── Mobile Menu Toggle ──────────────────────────────────
    window.toggleMobileMenu = function () {
        var mobileNav = document.getElementById('bloomyMobileNav');
        if (!mobileNav) return;
        mobileNav.classList.toggle('open');
        document.body.style.overflow = mobileNav.classList.contains('open') ? 'hidden' : '';
    };

    // Close mobile menu when clicking outside
    document.addEventListener('click', function (e) {
        var mobileNav = document.getElementById('bloomyMobileNav');
        if (!mobileNav || !mobileNav.classList.contains('open')) return;
        var toggle = document.querySelector('.bloomy-menu-toggle');
        if (!mobileNav.contains(e.target) && (!toggle || !toggle.contains(e.target))) {
            mobileNav.classList.remove('open');
            document.body.style.overflow = '';
        }
    });

    // ── Search Modal ────────────────────────────────────────
    window.toggleSearchModal = function () {
        var modal = document.getElementById('bloomySearchModal');
        if (!modal) return;
        modal.classList.toggle('open');
        if (modal.classList.contains('open')) {
            document.body.style.overflow = 'hidden';
            var input = document.getElementById('bloomySearchInput');
            if (input) setTimeout(function () { input.focus(); }, 100);
        } else {
            document.body.style.overflow = '';
        }
    };

    // Close search on backdrop click or Esc
    document.addEventListener('keydown', function (e) {
        if (e.key === 'Escape') {
            var modal = document.getElementById('bloomySearchModal');
            if (modal && modal.classList.contains('open')) {
                modal.classList.remove('open');
                document.body.style.overflow = '';
            }
            var mobileNav = document.getElementById('bloomyMobileNav');
            if (mobileNav && mobileNav.classList.contains('open')) {
                mobileNav.classList.remove('open');
                document.body.style.overflow = '';
            }
        }
    });

    document.addEventListener('click', function (e) {
        var modal = document.getElementById('bloomySearchModal');
        if (!modal || !modal.classList.contains('open')) return;
        if (e.target === modal) {
            modal.classList.remove('open');
            document.body.style.overflow = '';
        }
    });

    // ── Intersection Observer – Scroll Reveal ───────────────
    if ('IntersectionObserver' in window) {
        var revealObserver = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    entry.target.classList.add('visible');
                    revealObserver.unobserve(entry.target);
                }
            });
        }, { threshold: 0.12, rootMargin: '0px 0px -40px 0px' });

        document.addEventListener('DOMContentLoaded', function () {
            document.querySelectorAll('.reveal').forEach(function (el) {
                revealObserver.observe(el);
            });
        });

        // Also observe any elements already in DOM
        document.querySelectorAll('.reveal').forEach(function (el) {
            revealObserver.observe(el);
        });
    } else {
        // Fallback: show all reveal elements immediately
        document.querySelectorAll('.reveal').forEach(function (el) {
            el.classList.add('visible');
        });
    }

    // ── Smooth scroll for anchor links ──────────────────────
    document.addEventListener('click', function (e) {
        var link = e.target.closest('a[href^="#"]');
        if (!link) return;
        var targetId = link.getAttribute('href').slice(1);
        var target = document.getElementById(targetId);
        if (target) {
            e.preventDefault();
            var headerH = parseInt(getComputedStyle(document.documentElement).getPropertyValue('--header-h')) || 72;
            var top = target.getBoundingClientRect().top + window.scrollY - headerH - 16;
            window.scrollTo({ top: top, behavior: 'smooth' });
        }
    });

})();
