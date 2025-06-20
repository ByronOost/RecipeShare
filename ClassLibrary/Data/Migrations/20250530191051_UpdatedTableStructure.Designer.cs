﻿// <auto-generated />
using System;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassLibrary.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250530191051_UpdatedTableStructure")]
    partial class UpdatedTableStructure
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassLibrary.Models.DietaryTag", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RecipeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("RecipeID");

                    b.ToTable("DietaryTags");

                    b.HasData(
                        new
                        {
                            ID = new Guid("b2dca577-04a2-49b1-b140-7d74520a99e9"),
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Vegan"
                        },
                        new
                        {
                            ID = new Guid("eb540db0-23ab-4565-aef3-121fedd394d4"),
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Vegetarian"
                        },
                        new
                        {
                            ID = new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"),
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Gluten Free"
                        },
                        new
                        {
                            ID = new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"),
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Dairy Free"
                        },
                        new
                        {
                            ID = new Guid("e3a7c45f-90c3-4299-b202-f56bcf4e2c1f"),
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Keto"
                        },
                        new
                        {
                            ID = new Guid("91c456af-ef6f-4904-8f53-4fdd486e4b49"),
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Paleo"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.Recipe", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CookingTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Steps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            ID = new Guid("f2c1a3b5-6df7-4e9b-8c0d-59f62b6c3a92"),
                            CookingTime = 30,
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ingredients = "Spaghetti, Ground beef, Onion, Garlic, Tomatoes, Olive oil, Basil, Salt, Pepper",
                            IsActive = true,
                            IsDeleted = false,
                            Steps = "1. Boil spaghetti until al dente.\n2. Sauté onions and garlic in olive oil.\n3. Add ground beef and cook until browned.\n4. Stir in tomatoes and seasonings. Simmer 15 minutes.\n5. Combine with spaghetti and serve.",
                            Title = "Spaghetti Bolognese"
                        },
                        new
                        {
                            ID = new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5"),
                            CookingTime = 20,
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ingredients = "Quinoa, Cucumber, Tomato, Red onion, Lemon juice, Olive oil, Salt, Pepper, Parsley",
                            IsActive = true,
                            IsDeleted = false,
                            Steps = "1. Cook quinoa and let cool.\n2. Chop vegetables.\n3. Mix all ingredients in a bowl.\n4. Drizzle with lemon juice and olive oil.\n5. Season and toss to combine.",
                            Title = "Quinoa Salad"
                        },
                        new
                        {
                            ID = new Guid("c78fd9aa-3b6f-4663-bb79-fd408f2c3b45"),
                            CookingTime = 35,
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ingredients = "Chicken breast, Onion, Garlic, Ginger, Tomatoes, Coconut milk, Curry powder, Cumin, Salt, Pepper",
                            IsActive = true,
                            IsDeleted = false,
                            Steps = "1. Sauté onions, garlic, and ginger.\n2. Add chicken and cook until golden.\n3. Stir in curry powder and tomatoes.\n4. Add coconut milk and simmer for 20 minutes.\n5. Serve with rice.",
                            Title = "Chicken Curry"
                        },
                        new
                        {
                            ID = new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654"),
                            CookingTime = 25,
                            CreatedDate = new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ingredients = "Taco shells, Black beans, Corn, Avocado, Tomato, Lettuce, Lime juice, Cumin, Chili powder",
                            IsActive = true,
                            IsDeleted = false,
                            Steps = "1. Heat beans with cumin and chili powder.\n2. Prepare vegetables and toppings.\n3. Warm taco shells.\n4. Assemble tacos with beans and toppings.\n5. Drizzle with lime juice and serve.",
                            Title = "Vegan Tacos"
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.RecipeDietaryTag", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DietaryTagID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecipeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("DietaryTagID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeDietaryTags");

                    b.HasData(
                        new
                        {
                            ID = new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654"),
                            DietaryTagID = new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"),
                            RecipeID = new Guid("f2c1a3b5-6df7-4e9b-8c0d-59f62b6c3a92")
                        },
                        new
                        {
                            ID = new Guid("2c7e1d68-3f55-4e45-9d29-04b71de82cf2"),
                            DietaryTagID = new Guid("b2dca577-04a2-49b1-b140-7d74520a99e9"),
                            RecipeID = new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5")
                        },
                        new
                        {
                            ID = new Guid("3f1a4ae9-d843-4cb2-9373-8f9e1df2ecb9"),
                            DietaryTagID = new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"),
                            RecipeID = new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5")
                        },
                        new
                        {
                            ID = new Guid("45c5e3cc-6c6c-47f3-9a36-c4a9fca2ee3e"),
                            DietaryTagID = new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"),
                            RecipeID = new Guid("0e1fa394-43cf-4d2c-b22c-9c12dc349ab5")
                        },
                        new
                        {
                            ID = new Guid("51d94b7a-9e30-4126-8ff1-06658cfdcb84"),
                            DietaryTagID = new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"),
                            RecipeID = new Guid("c78fd9aa-3b6f-4663-bb79-fd408f2c3b45")
                        },
                        new
                        {
                            ID = new Guid("6aeb3d24-b64d-4192-a7d2-24a3c8c25e3d"),
                            DietaryTagID = new Guid("b2dca577-04a2-49b1-b140-7d74520a99e9"),
                            RecipeID = new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654")
                        },
                        new
                        {
                            ID = new Guid("72e453b5-c70a-4a3e-8799-24e914deec77"),
                            DietaryTagID = new Guid("c3e77a81-6e3c-4a31-a7f1-f80d94d5d0a7"),
                            RecipeID = new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654")
                        },
                        new
                        {
                            ID = new Guid("83b61f61-f0f0-4b3a-9ae6-36f771d3ce6e"),
                            DietaryTagID = new Guid("a9f1a2d8-6b39-4b52-91e0-df71259a8e7f"),
                            RecipeID = new Guid("1b4c9c75-5a93-4082-8aeb-42a8c138f654")
                        });
                });

            modelBuilder.Entity("ClassLibrary.Models.DietaryTag", b =>
                {
                    b.HasOne("ClassLibrary.Models.Recipe", null)
                        .WithMany("DietaryTags")
                        .HasForeignKey("RecipeID");
                });

            modelBuilder.Entity("ClassLibrary.Models.RecipeDietaryTag", b =>
                {
                    b.HasOne("ClassLibrary.Models.DietaryTag", "DietaryTag")
                        .WithMany()
                        .HasForeignKey("DietaryTagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DietaryTag");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("ClassLibrary.Models.Recipe", b =>
                {
                    b.Navigation("DietaryTags");
                });
#pragma warning restore 612, 618
        }
    }
}
