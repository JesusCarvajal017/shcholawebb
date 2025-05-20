using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Entity.Migrations
{
    /// <inheritdoc />
    public partial class Securityi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "security");

            migrationBuilder.CreateTable(
                name: "form",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_form", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "module",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    identification = table.Column<int>(type: "integer", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "moduleForm",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    module_id = table.Column<int>(type: "integer", nullable: false),
                    form_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moduleForm", x => x.id);
                    table.ForeignKey(
                        name: "FK_moduleForm_form_form_id",
                        column: x => x.form_id,
                        principalSchema: "security",
                        principalTable: "form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_moduleForm_module_module_id",
                        column: x => x.module_id,
                        principalSchema: "security",
                        principalTable: "module",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_user_person_person_id",
                        column: x => x.person_id,
                        principalSchema: "security",
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rolFormPermission",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rol_id = table.Column<int>(type: "integer", nullable: false),
                    form_id = table.Column<int>(type: "integer", nullable: false),
                    permission_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolFormPermission", x => x.id);
                    table.ForeignKey(
                        name: "FK_rolFormPermission_form_form_id",
                        column: x => x.form_id,
                        principalSchema: "security",
                        principalTable: "form",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rolFormPermission_permission_permission_id",
                        column: x => x.permission_id,
                        principalSchema: "security",
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rolFormPermission_rol_rol_id",
                        column: x => x.rol_id,
                        principalSchema: "security",
                        principalTable: "rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userRol",
                schema: "security",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    rol_id = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRol", x => x.id);
                    table.ForeignKey(
                        name: "FK_userRol_rol_rol_id",
                        column: x => x.rol_id,
                        principalSchema: "security",
                        principalTable: "rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userRol_user_user_id",
                        column: x => x.user_id,
                        principalSchema: "security",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "security",
                table: "form",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "status", "updated_at" },
                values: new object[] { 1, null, null, "Módulo de gestión de usuarios", "Usuarios", 1, null });

            migrationBuilder.InsertData(
                schema: "security",
                table: "module",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "status", "updated_at" },
                values: new object[] { 1, null, null, "Todo el tema de permisos del sistema", "Seguridad", 1, null });

            migrationBuilder.InsertData(
                schema: "security",
                table: "permission",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "status", "updated_at" },
                values: new object[] { 1, null, null, "Formulario de inicio", "system complete", 1, null });

            migrationBuilder.InsertData(
                schema: "security",
                table: "person",
                columns: new[] { "id", "Age", "created_at", "deleted_at", "identification", "last_name", "name", "status", "updated_at" },
                values: new object[] { 1, 19, null, null, 1076503110, "Carvajal", "Jesus", 1, null });

            migrationBuilder.InsertData(
                schema: "security",
                table: "rol",
                columns: new[] { "id", "created_at", "deleted_at", "description", "name", "status", "updated_at" },
                values: new object[] { 1, null, null, "Control sobre todo", "Admin", 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_moduleForm_form_id",
                schema: "security",
                table: "moduleForm",
                column: "form_id");

            migrationBuilder.CreateIndex(
                name: "IX_moduleForm_module_id",
                schema: "security",
                table: "moduleForm",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_rolFormPermission_form_id",
                schema: "security",
                table: "rolFormPermission",
                column: "form_id");

            migrationBuilder.CreateIndex(
                name: "IX_rolFormPermission_permission_id",
                schema: "security",
                table: "rolFormPermission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "IX_rolFormPermission_rol_id",
                schema: "security",
                table: "rolFormPermission",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_person_id",
                schema: "security",
                table: "user",
                column: "person_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_userRol_rol_id",
                schema: "security",
                table: "userRol",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "IX_userRol_user_id",
                schema: "security",
                table: "userRol",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "moduleForm",
                schema: "security");

            migrationBuilder.DropTable(
                name: "rolFormPermission",
                schema: "security");

            migrationBuilder.DropTable(
                name: "userRol",
                schema: "security");

            migrationBuilder.DropTable(
                name: "module",
                schema: "security");

            migrationBuilder.DropTable(
                name: "form",
                schema: "security");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "security");

            migrationBuilder.DropTable(
                name: "rol",
                schema: "security");

            migrationBuilder.DropTable(
                name: "user",
                schema: "security");

            migrationBuilder.DropTable(
                name: "person",
                schema: "security");
        }
    }
}
