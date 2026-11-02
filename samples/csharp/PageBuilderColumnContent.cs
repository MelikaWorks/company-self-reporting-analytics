// Selected Page Builder excerpt from the migration milestone.
// Host controller, entity classes and supporting views are intentionally omitted.

// Twelve predefined column layouts have distinct content slots.
private static void ApplyColumnContent(PageBuilderCust_tb entity, PageBuildCustViewModel vm)
        {
            switch (vm.Col_ID)
            {
                case 1:
                    entity.PagBC_C1 = vm.PagBC_C1;
                    break;

                case 2:
                    entity.PagBC_C2C1 = vm.PagBC_C2C1;
                    entity.PagBC_C2C2 = vm.PagBC_C2C2;
                    break;

                case 3:
                    entity.PagBC_C3C1 = vm.PagBC_C3C1;
                    entity.PagBC_C3C2 = vm.PagBC_C3C2;
                    entity.PagBC_C3C3 = vm.PagBC_C3C3;
                    break;

                case 4:
                    entity.PagBC_C4C1 = vm.PagBC_C4C1;
                    entity.PagBC_C4C2 = vm.PagBC_C4C2;
                    entity.PagBC_C4C3 = vm.PagBC_C4C3;
                    entity.PagBC_C4C4 = vm.PagBC_C4C4;
                    break;

                case 5:
                    entity.PagBC_C5C1 = vm.PagBC_C5C1;
                    entity.PagBC_C5C2 = vm.PagBC_C5C2;
                    entity.PagBC_C5C3 = vm.PagBC_C5C3;
                    entity.PagBC_C5C4 = vm.PagBC_C5C4;
                    entity.PagBC_C5C5 = vm.PagBC_C5C5;
                    break;

                case 6:
                    entity.PagBC_C6C1 = vm.PagBC_C6C1;
                    entity.PagBC_C6C2 = vm.PagBC_C6C2;
                    entity.PagBC_C6C3 = vm.PagBC_C6C3;
                    entity.PagBC_C6C4 = vm.PagBC_C6C4;
                    entity.PagBC_C6C5 = vm.PagBC_C6C5;
                    entity.PagBC_C6C6 = vm.PagBC_C6C6;
                    break;

                case 7:
                    entity.PagBC_C7C1 = vm.PagBC_C7C1;
                    entity.PagBC_C7C2 = vm.PagBC_C7C2;
                    break;

                case 8:
                    entity.PagBC_C8C1 = vm.PagBC_C8C1;
                    entity.PagBC_C8C2 = vm.PagBC_C8C2;
                    break;

                case 9:
                    entity.PagBC_C9C1 = vm.PagBC_C9C1;
                    entity.PagBC_C9C2 = vm.PagBC_C9C2;
                    entity.PagBC_C9C3 = vm.PagBC_C9C3;
                    break;

                case 10:
                    entity.PagBC_C10C1 = vm.PagBC_C10C1;
                    entity.PagBC_C10C2 = vm.PagBC_C10C2;
                    entity.PagBC_C10C3 = vm.PagBC_C10C3;
                    break;

                case 11:
                    entity.PagBC_C11C1 = vm.PagBC_C11C1;
                    entity.PagBC_C11C2 = vm.PagBC_C11C2;
                    entity.PagBC_C11C3 = vm.PagBC_C11C3;
                    break;

                case 12:
                    entity.PagBC_C12C1 = vm.PagBC_C12C1;
                    entity.PagBC_C12C2 = vm.PagBC_C12C2;
                    entity.PagBC_C12C3 = vm.PagBC_C12C3;
                    break;
            }
        }
