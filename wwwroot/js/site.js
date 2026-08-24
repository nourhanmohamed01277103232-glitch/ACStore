
document.addEventListener('DOMContentLoaded', () => {
    const cards = document.querySelectorAll('.product-card, .feature-card, .stat-card, .quick-link-card');
    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, { threshold: 0.1 });

    cards.forEach(card => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(20px)';
        card.style.transition = 'opacity .5s ease, transform .5s ease';
        observer.observe(card);
    });

  
    document.querySelectorAll('.btn-hero-cta, .btn-order-cta').forEach(btn => {
        btn.addEventListener('click', function () {
            this.classList.add('clicked-pulse');
            setTimeout(() => this.classList.remove('clicked-pulse'), 300);
        });
    });
});
