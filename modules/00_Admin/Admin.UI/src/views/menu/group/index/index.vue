<template>
  <m-drawer title="分组管理" icon="list" width="900px" no-scrollbar>
    <m-list ref="listRef" :header="false" :cols="cols" :query-model="model" :query-method="query">
      <template #querybar>
        <el-form-item label="名称：" prop="name">
          <el-input v-model="model.name" clearable />
        </el-form-item>
      </template>
      <template #buttons>
        <m-button-add :code="buttons.groupAdd.code" @click="add" />
      </template>
      <template #operation="{ row }">
        <m-button-edit :code="buttons.groupEdit.code" @click="edit(row)" @success="handleChange"></m-button-edit>
        <m-button-delete :code="buttons.groupRemove.code" :action="remove" :data="row.id" @success="handleChange"></m-button-delete>
      </template>
    </m-list>
    <save :id="selection.id" v-model="saveVisible" :mode="mode" @success="handleChange" />
  </m-drawer>
</template>
<script>
import { useList, entityBaseCols } from 'mkh-ui'
import { reactive } from 'vue'
import { buttons } from '../../index/page.json'
import Save from '../save/index.vue'
export default {
  components: { Save },
  emits: ['change'],
  setup(props, { emit }) {
    const { query, remove } = mkh.api.admin.menuGroup
    const model = reactive({ name: '' })
    const cols = [{ prop: 'id', label: '编号', width: '55', show: false }, { prop: 'name', label: '名称' }, { prop: 'remarks', label: '备注' }, ...entityBaseCols]

    const list = useList()

    const handleChange = () => {
      list.refresh()
      emit('change')
    }

    return {
      buttons,
      model,
      cols,
      query,
      remove,
      ...list,
      handleChange,
    }
  },
}
</script>
