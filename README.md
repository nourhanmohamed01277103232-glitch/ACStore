# ACStore — Ideal H2O Sales Management System

A full sales management web platform for **Ideal H2O**, a company selling air conditioners and water filters — cash or installments. Built end-to-end with **ASP.NET Core MVC**, from database design to a complete admin dashboard.

---

## 💡 Project Idea

ACStore serves two types of users:
- **Customer**: browses products, views details & price, calculates monthly installments
- **Admin**: manages inventory, sales, and monthly review from a dedicated dashboard

The goal was to build a portfolio-ready, real-world web application — not a tutorial clone — covering the full stack from database modeling to UI/UX.

---

## 🧰 Tech Stack

- **ASP.NET Core MVC** — core framework
- **Entity Framework Core** (Code-First) — database access
- **SQL Server** — data storage
- **ASP.NET Core Identity** — authentication & roles (Admin / Customer)
- **LINQ** — filtering, calculations, and reports
- **Bootstrap + Custom CSS** — responsive layout with a custom visual identity

---

## ✨ Features

### Customer side
- Animated hero section on the home page
- Product catalog with type filtering (Air Conditioners / Water Filters) — powered by LINQ
- Real-time stock & price data pulled directly from SQL Server
- Product details page

### Admin side
- Protected dashboard (ASP.NET Identity)
- Stats overview: total products, orders, low-stock alerts
- Full inventory CRUD — add / edit / delete products, link images
- Sales tracking — customer, product, payment method, total per order
- Monthly review for installment tracking

---

## 🖼️ Screenshots

<!-- ضيفي صور من فولدر screenshots هنا، مثال: -->
<!-- ![Home Page](screenshots/home.png) -->
<!-- ![Products Page](screenshots/products.png) -->
<!-- ![Admin Dashboard](screenshots/admin_dashboard.png) -->

---

## 🧩 Development Workflow

Database design → Customer pages → Authentication → Admin dashboard → Visual design & branding → Testing & polish

---

## 🚧 Challenges Faced

- Fixed a `CS0019` error caused by comparing a C# `enum` to a raw string — resolved with `.ToString()`
- Debugged an image-404 issue caused by files not being physically copied to disk
- Corrected an inverted availability condition that showed "Out of stock" on all products
- Resolved a CSS class conflict that caused mismatched card heights across sections

---

## 🚀 What's Next

- Online payment gateway
- Product ratings & reviews
- A mobile app using the same backend
- More detailed admin analytics
- Multi-language support (Arabic / English)

---

## 👩‍💻 Author

**Nourhan** — .NET Web Development Track, Information Technology Institute (ITI)
